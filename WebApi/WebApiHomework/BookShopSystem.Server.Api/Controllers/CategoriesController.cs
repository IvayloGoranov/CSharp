using System.Linq;
using System.Web.Http;

using BookShopSystem.Data.Interfaces;
using BookShopSystem.Server.Api.DTOs.ViewModels;
using BookShopSystem.Server.Api.DTOs.InputModels;

namespace BookShopSystem.Server.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private IBookShopContext context;

        public CategoriesController(IBookShopContext context)
        {
            this.context = context;
        }

        // GET api/categories
        public IHttpActionResult GetAllCategories()
        {
            var allCtageories = this.context.Categories
                .Select(CategoryViewModel.MapToViewModel).ToList(); 

            return this.Ok(allCtageories);
        }

        // GET api/categories/{id}
        public IHttpActionResult GetCategoryById(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var category = this.context.Categories
                .Where(x => x.Id == id)
                .Select(CategoryViewModel.MapToViewModel)
                .FirstOrDefault();

            if (category == null)
            {
                return this.BadRequest(string.Format("No category with id {0} found", id));
            }

            return this.Ok(category);
        }

        // PUT api/books/{id}
        public IHttpActionResult Put(int id, CategoryInputModel category)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var categoryToEdit = this.context.Categories.Find(id);

            if (categoryToEdit == null)
            {
                return this.BadRequest(string.Format("No category with id {0} found", id));
            }

            if (categoryToEdit.CategoryName != category.CategoryName)
            {
                var existingCategory = this.context.Categories
                    .Where(x => x.CategoryName == category.CategoryName)
                    .FirstOrDefault();
                if (existingCategory != null)
                {
                    return this.BadRequest(
                        string.Format("There is already a category named {0}", category.CategoryName));
                }

                category.UpdateCategory(categoryToEdit);
                this.context.SaveChanges();
            }

            return this.Ok();
        }

        // DELETE api/categories/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var categoryToDelete = this.context.Categories.Find(id);

            if (categoryToDelete == null)
            {
                return this.BadRequest(string.Format("No category with id {0} found", id));
            }

            this.context.Categories.Remove(categoryToDelete);
            this.context.SaveChanges();

            return this.Ok();
        }

        // POST api/categories
        public IHttpActionResult Post(CategoryInputModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingCategory = this.context.Categories
                    .Where(x => x.CategoryName == category.CategoryName)
                    .FirstOrDefault();
            if (existingCategory != null)
            {
                return this.BadRequest(
                    string.Format("There is already a category named {0}", category.CategoryName));
            }

            var newCategory = category.CreateCategory();
            this.context.Categories.Add(newCategory);
            this.context.SaveChanges();

            return this.Ok();
        }
    }
}
