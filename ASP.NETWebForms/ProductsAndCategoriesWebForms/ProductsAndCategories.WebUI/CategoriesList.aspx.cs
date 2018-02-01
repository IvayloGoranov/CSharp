using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProductsAndCategories.BusinessObject;
using ProductsAndCategories.Ordering.Data;

namespace ProductsAndCategories.WebUI
{
    public partial class CategoriesList : Page
    {
        private const string DetailsPage = "CategoryDetails.aspx";
        private const string CategoryName = "CategoryName";
        private const string ItemsCount = "ItemsCount";
        private const string ImageDownGray = "down_gray.png";
        private const string ImageUpGray = "up_gray.png";

        private readonly Categories categoryBusinessObject = new Categories();

        public int ItemsToShowCount { get; set; }

        public string NameFilter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ItemsToShowCount = GlobalConstants.GlobalConstants.DefaultItemsCount;
                this.SetItemsCountToCookie();
                this.BindData();

                this.btnDeleteSelected.OnClientClick = string.Format("return confirm('{0}')", "Are you sure you want to delete selected item?");
            }
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            this.GetItemsCountFromCookie();
            this.BindData();
        }

        protected void lnkReset_Click(object sender, EventArgs e)
        {
            this.txtNameFilter.Text = string.Empty;
            this.GetItemsCountFromCookie();
            this.BindData();
        }

        protected void lvCategories_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int currentOrderNo = 0;

            switch (e.CommandName)
            {
                case "EditItem":
                    this.Response.Redirect(string.Format("{0}?id={1}", DetailsPage, e.CommandArgument.ToString()));
                    break;
                case "MoveUp":
                    if (int.TryParse(e.CommandArgument.ToString(), out currentOrderNo))
                    {
                        this.GetItemsCountFromCookie();
                        IEnumerable<CategoryItem> categories = this.GetCategoriesFiltered();

                        CategoryItem previousCategory = null;
                        int previousCategoryOrderNo = 0;
                        int currentCategoryId = 0;
                        foreach (var category in categories)
                        {
                            if (category.OrderNo == currentOrderNo)
                            {
                                currentCategoryId = category.Id;

                                break;
                            }

                            if (category.OrderNo < currentOrderNo)
                            {
                                if (category.OrderNo > previousCategoryOrderNo)
                                {
                                    previousCategory = category;
                                    previousCategoryOrderNo = previousCategory.OrderNo;
                                }
                            }
                        }

                        if (previousCategory != null)
                        {
                            var currentCategory = categoryBusinessObject.Get(currentCategoryId);
                            currentCategory.OrderNo = previousCategory.OrderNo;
                            categoryBusinessObject.Save(currentCategory);
                            previousCategory.OrderNo = currentOrderNo;
                            categoryBusinessObject.Save(previousCategory);

                            this.BindData();
                        }
                    }

                    break;
                case "MoveDown":
                    if (int.TryParse(e.CommandArgument.ToString(), out currentOrderNo))
                    {
                        this.GetItemsCountFromCookie();
                        IEnumerable<CategoryItem> categories = this.GetCategoriesFiltered();

                        CategoryItem nextCategory = null;
                        int nextCategoryOrderNo = int.MaxValue;
                        int currentCategoryId = 0;
                        foreach (var category in categories)
                        {
                            if (category.OrderNo == currentOrderNo)
                            {
                                currentCategoryId = category.Id;
                            }

                            if (category.OrderNo > currentOrderNo)
                            {
                                if (category.OrderNo < nextCategoryOrderNo)
                                {
                                    nextCategory = category;
                                    nextCategoryOrderNo = nextCategory.OrderNo;
                                }
                            }
                        }

                        if (nextCategory != null)
                        {
                            var currentCategory = categoryBusinessObject.Get(currentCategoryId);
                            currentCategory.OrderNo = nextCategory.OrderNo;
                            categoryBusinessObject.Save(currentCategory);
                            nextCategory.OrderNo = currentOrderNo;
                            categoryBusinessObject.Save(nextCategory);

                            this.BindData();
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        protected void lvCategories_DataBound(object sender, EventArgs e)
        {
            if (lvCategories.Items != null && lvCategories.Items.Count > 0)
            {
                Control btnMoveDown = lvCategories.Items[lvCategories.Items.Count - 1].FindControl("btnMoveDown");
                if (btnMoveDown != null)
                {
                    btnMoveDown.Visible = false;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(DetailsPage);
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            List<int> itemsToDelete = new List<int>();
            foreach (ListViewItem item in lvCategories.Items)
            {
                if (item.ItemType == ListViewItemType.DataItem)
                {
                    CheckBox chb = item.FindControl("chkSelected") as CheckBox;
                    HiddenField hf = item.FindControl("hfID") as HiddenField;
                    if (chb != null && hf != null)
                    {
                        if (chb.Checked)
                        {
                            int id = 0;
                            if (int.TryParse(hf.Value, out id))
                            {
                                itemsToDelete.Add(id);
                            }
                            else
                            {
                                itemsToDelete.Clear();
                                break;
                            }
                        }
                    }
                }
            }

            this.Delete(itemsToDelete);
        }

        protected void btnViewMore_Click(object sender, EventArgs e)
        {
            this.GetItemsCountFromCookie();
            this.ItemsToShowCount = this.ItemsToShowCount + GlobalConstants.GlobalConstants.DefaultItemsCount;
            this.SetItemsCountToCookie();
            this.BindData();
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelectAll = sender as CheckBox;

            if (chkSelectAll.Checked)
            {
                foreach (ListViewItem item in lvCategories.Items)
                {
                    if (item.ItemType == ListViewItemType.DataItem)
                    {
                        CheckBox chb = item.FindControl("chkSelected") as CheckBox;
                        chb.Checked = true;
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in lvCategories.Items)
                {
                    if (item.ItemType == ListViewItemType.DataItem)
                    {
                        CheckBox chb = item.FindControl("chkSelected") as CheckBox;
                        if (chb != null)
                        {
                            chb.Checked = false;
                        }
                    }
                }
            }
        }

        protected string DownButtonImage(object item)
        {
            string result = string.Format("~/images/{0}", ImageDownGray);

            return result;
        }

        protected string UpButtonImage(object item)
        {
            string result = string.Format("~/images/{0}", ImageUpGray);

            return result;
        }

        protected string GetColorAsClass(object colorValue)
        {
            return colorValue.ToString() + "-background";
        }

        private HttpCookie SetCookie(string cookieName, NameValueCollection values, DateTime expirationDate)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Add(values);
            cookie.Expires = expirationDate;

            return cookie;
        }

        private NameValueCollection GetCookieValues(HttpRequest request, string cookieName)
        {
            NameValueCollection result = null;

            HttpCookie cookie = new HttpCookie(cookieName);
            cookie = request.Cookies[cookieName];
            if (cookie != null)
            {
                result = cookie.Values;
            }

            return result;
        }

        private void Delete(List<int> itemsToDelete)
        {
            if (itemsToDelete.Count > 0)
            {
                var categoryBusinessObject = new Categories();
                foreach (var id in itemsToDelete)
                {
                    categoryBusinessObject.Delete(id);
                }

                this.GetItemsCountFromCookie();
                this.BindData();
                lblActionStatus.Text = "Categories deleted";
            }
        }

        private void BindData()
        {
            IEnumerable<CategoryItem> categories = this.GetCategoriesFiltered();
            this.lvCategories.DataSource = categories;
            this.lvCategories.DataBind();

            this.ltItemsToShowCount.Text = this.ItemsToShowCount < categories.Count() ? this.ItemsToShowCount.ToString() : categories.Count().ToString();
            this.ltAllItemsCount.Text = this.categoryBusinessObject.GetCount().ToString();
        }

        private IEnumerable<CategoryItem> GetCategoriesFiltered()
        {
            string nameFilter = this.txtNameFilter.Text.Trim() == string.Empty ? null : this.txtNameFilter.Text.Trim();
            IEnumerable<CategoryItem> categories = this.categoryBusinessObject.GetFilteredCategories(this.ItemsToShowCount, nameFilter)
                                                                              .OrderBy(x => x.OrderNo);

            return categories;
        }

        private void GetItemsCountFromCookie()
        {
            NameValueCollection getCookies = this.GetCookieValues(this.Request, this.GetType().BaseType.Name);
            if (getCookies != null)
            {
                this.ItemsToShowCount = int.Parse(getCookies[ItemsCount]);
            }
        }

        private void SetItemsCountToCookie()
        {
            NameValueCollection cookies = new NameValueCollection();
            cookies.Add(ItemsCount, this.ItemsToShowCount.ToString());
            Response.Cookies.Set(this.SetCookie(this.GetType().BaseType.Name, cookies, DateTime.Now.AddMonths(1)));
        }
    }
}