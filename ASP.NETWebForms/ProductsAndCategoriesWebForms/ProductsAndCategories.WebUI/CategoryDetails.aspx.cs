using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using ProductsAndCategories.Data.Enums;
using ProductsAndCategories.BusinessObject;
using ProductsAndCategories.Ordering.Data;

namespace ProductsAndCategories.WebUI
{
    public partial class CategoryDetails : Page
    {
        private const string CategoriesListPage = "CategoriesList.aspx";
        private const string GreenColor = "green";
        private const string BlueColor = "blue";
        private const string RedColor = "red";

        private readonly Products productsBusinessObject = new Products();
        private readonly Categories categoryBusinessObject = new Categories();

        public int Id
        {
            get { return this.GetPropertyValue<int>("Id", 0); }
            set { this.SetPropertyValue<int>("Id", value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (int.TryParse(this.Request.QueryString["id"], out id))
                {
                    this.Id = id;
                    this.BindData();
                }
                else
                {
                    this.lblValidationStatus.Text = "Invalid id";
                }

                this.btnDelete.OnClientClick = string.Format("return confirm('{0}')", "Are you sure you want to delete selected item?");            
            }
        }

        protected void btnChangeColor_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandArgument as string)
            {
                case "Green":
                    this.ChangeCategoryColor(Color.green);
                    break;
                case "Blue":
                    this.ChangeCategoryColor(Color.blue);
                    break;
                case "Red":
                    this.ChangeCategoryColor(Color.red);
                    break;
                default:
                    break;
            }
        }

        protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            HiddenField hfID = e.Item.FindControl("hfID") as HiddenField;
            if (hfID ==  null)
            {
                return;
            }

            int productId;
            if (!int.TryParse(hfID.Value, out productId))
            {
                return;
            }

            switch (e.CommandName)
            {
                case "EditItem":
                    if (this.Page.IsValid)
                    {
                        try
                        {
                            ProductItem product = this.productsBusinessObject.Get(productId);

                            TextBox txtPrice = e.Item.FindControl("txtPrice") as TextBox;
                            TextBox txtProductName = e.Item.FindControl("txtProductName") as TextBox;
                            if (txtPrice != null && txtProductName != null)
                            {
                                decimal price;
                                if (decimal.TryParse(txtProductName.Text, out price) && price >= 0)
                                {
                                    product.Price = price;
                                    product.Name = txtProductName.Text;

                                    this.productsBusinessObject.Save(product);
                                    lblActionStatus.Text = "Product updated";
                                }
                                else
                                {
                                    CustomValidator cvPrice = e.Item.FindControl("cvPrice") as CustomValidator;
                                    cvPrice.IsValid = false;
                                }
                            }
                        }
                        catch (KeyNotFoundException ex)
                        {
                            this.lblValidationStatus.Text = ex.Message;
                            return;
                        }
                        catch (ArgumentException ex)
                        {
                            this.lblValidationStatus.Text = ex.Message;
                            return;
                        }
                    }

                    break;

                case "DeleteItem":
                    this.productsBusinessObject.Delete(productId);
                    this.BindData();

                    break;
                default:
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(this.Page.IsValid)
            {
                CategoryItem category = new CategoryItem();
                if (this.Id > 0)
                {
                    try
                    {
                        category = this.categoryBusinessObject.Get(this.Id);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        this.lblValidationStatus.Text = ex.Message;
                        return;
                    }
                    
                }

                category.Name = this.txtCategoryName.Text.Trim();
                category.Description = this.txtDescription.Text.Trim();

                CategoryItem categoryInDb = this.categoryBusinessObject.Save(category);
                this.Id = categoryInDb.Id;
                this.BindData();
                this.lblActionStatus.Text = "Category saved";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Id <= 0)
            {
                this.lblActionStatus.Text = "Nothing to delete";

                return;
            }

            this.categoryBusinessObject.Delete(this.Id);

            this.Response.Redirect(CategoriesListPage);
        }

        protected void lnkAddItem_Click(object sender, EventArgs e)
        {
            if (this.Id <= 0)
            {
                this.lblActionStatus.Text = "Add category first";

                return;
            }

            if (this.Page.IsValid)
            {
                try
                {
                    ProductItem product = new ProductItem();

                    decimal price;
                    if (decimal.TryParse(this.txtNewPrice.Text, out price) && price >= 0)
                    {
                        product.Price = price;
                        product.Name = this.txtNewProductName.Text.Trim();
                        product.CategoryId = this.Id;

                        this.productsBusinessObject.Save(product);
                        this.lblActionStatus.Text = "Product added";
                        this.BindData();
                    }
                    else
                    {
                        this.cvNewPrice.IsValid = false;
                    }
                }
                catch (KeyNotFoundException ex)
                {
                    this.lblValidationStatus.Text = ex.Message;
                    return;
                }
                catch (ArgumentException ex)
                {
                    this.lblValidationStatus.Text = ex.Message;
                    return;
                }
            }
        }

        private V GetPropertyValue<V>(string propertyName, V nullValue)
        {
            if (this.ViewState[propertyName] == null)
            {
                return nullValue;
            }

            return (V)this.ViewState[propertyName];
        }

        private void SetPropertyValue<V>(string propertyName, V value)
        {
            this.ViewState[propertyName] = value;
        }

        private void BindData()
        {
            try
            {
                IEnumerable<ProductItem> products = this.productsBusinessObject.GetProductsByCategoryID(this.Id);
                this.lvProducts.DataSource = products;
                this.lvProducts.DataBind();

                CategoryItem category = this.categoryBusinessObject.Get(this.Id);
                this.txtCategoryName.Text = category.Name;
                this.txtDescription.Text = category.Description;
                this.boxBackgroundColor.Attributes.Add("class", this.GetColorAsClass(category.Color));
            }
            catch (KeyNotFoundException e)
            {
                this.lblValidationStatus.Text = e.Message;
            }
        }

        private string GetColorAsClass(Color color)
        {
            string colorAsClass = string.Empty;

            switch (color)
            {
                case Color.green:
                    colorAsClass = GreenColor;
                    break;
                case Color.blue:
                    colorAsClass = BlueColor;
                    break;
                case Color.red:
                    colorAsClass = RedColor;
                    break;
                default:
                    colorAsClass = GreenColor;
                    break;
            }

            colorAsClass += "-background box";

            return colorAsClass;
        }

        private void ChangeCategoryColor(Color color)
        {
            CategoryItem category = this.categoryBusinessObject.Get(this.Id);
            category.Color = color;
            this.categoryBusinessObject.Save(category);
            this.boxBackgroundColor.Attributes.Add("class", this.GetColorAsClass(category.Color));
        }

        //private bool IsProductValid(ListViewItem item)
        //{
        //    TextBox txtPrice = null;
        //    TextBox txtProductName = null;
        //    if (item != null)
        //    {
        //        txtPrice = item.FindControl("txtPrice") as TextBox;
        //        txtProductName = item.FindControl("txtProductName") as TextBox;
        //    }
        //    else
        //    {
        //        txtPrice = this.txtNewPrice;
        //        txtProductName = this.txtNewProductName;
        //    }
            
        //    decimal price;
        //    if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
        //    {
        //        this.lblValidationStatus.Text = "Invalid price value";

        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
        //    {
        //        this.lblValidationStatus.Text = "Product name value is required";

        //        return false;
        //    }

        //    return true;
        //}

        //private bool IsCategoryValid()
        //{
        //    if (string.IsNullOrEmpty(this.txtCategoryName.Text.Trim()))
        //    {
        //        this.lblValidationStatus.Text = "Category name value is required";

        //        return false;
        //    }

        //    return true;
        //}
    }
}