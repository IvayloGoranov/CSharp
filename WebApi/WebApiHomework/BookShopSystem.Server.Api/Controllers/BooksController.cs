using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;

using BookShopSystem.Data.Interfaces;
using BookShopSystem.Server.Api.DTOs.ViewModels;
using BookShopSystem.Server.Api.DTOs.InputModels;
using BookShopSystem.Models;
using System.Data.Entity.Infrastructure;

namespace BookShopSystem.Server.Api.Controllers
{
    public class BooksController : ApiController
    {
        private IBookShopContext context;

        public BooksController(IBookShopContext context)
        {
            this.context = context;
        }

        // GET api/books/{id}
        public IHttpActionResult GetBookById(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var book = this.context.Books
                .Include(x => x.Author)
                .Include(x => x.Categories)
                .Where(x => x.Id == id)
                .Select(BookViewModel.MapToViewModel)
                .FirstOrDefault();

            if (book == null)
            {
                return this.BadRequest(string.Format("No book with id {0} found", id));
            }

            return this.Ok(book);
        }

        // GET api/books?search={word}
        public IHttpActionResult GetBooksByTitle([FromUri]string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return this.BadRequest();
            }

            var books = this.context.Books
                .Where(x => x.Title.Contains(search))
                .Select(x => new
                {
                    x.Title,
                    x.Id
                })
                .ToList();

            if (books == null)
            {
                return Content(HttpStatusCode.NotFound,
                    string.Format("No books matching search query {0} found", search));
            }

            return this.Ok(books);
        }

        // PUT api/books/{id}
        public IHttpActionResult Put(int id, BookInputModel book)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bookToEdit = this.context.Books.Find(id);

            if (bookToEdit == null)
            {
                return this.BadRequest(string.Format("No book with id {0} found", id));
            }

            book.UpdateBook(bookToEdit);
            this.context.SaveChanges();

            return this.Ok();
        }

        // DELETE api/books/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var bookToDelete = this.context.Books.Find(id);

            if (bookToDelete == null)
            {
                return this.BadRequest(string.Format("No book with id {0} found", id));
            }

            this.context.Books.Remove(bookToDelete);
            this.context.SaveChanges();

            return this.Ok();
        }

        // POST api/books
        public IHttpActionResult Post(BookInputModel book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newBook = book.CreateBook();
            var author = this.context.Authors.Find(book.AuthorId);
            if (author != null)
            {
                newBook.Author = author;
            }

            string[] categoryNames = book.CategoryNames.Split(new char[] { ' '});
            foreach (var categoryName in categoryNames)
            {
                var existingCategory = this.context.Categories.
                    Where(x => x.CategoryName == categoryName).
                    FirstOrDefault();
                if (existingCategory == null)
                {
                    existingCategory = new Category
                    {
                        CategoryName = categoryName
                    };

                    this.context.Categories.Add(existingCategory);
                }

                newBook.Categories.Add(existingCategory);
                existingCategory.Books.Add(newBook);
            }

            this.context.Books.Add(newBook);
            this.context.SaveChanges();
            //try
            //{
            //    this.context.SaveChanges();
            //}
            //catch (DbUpdateException ex)
            //{
            //    return this.Ok(ex.InnerException);
            //}

            return this.Ok();
        }
    }
}
