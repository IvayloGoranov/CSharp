using System.Web.Http;
using System.Data.Entity;
using System.Linq;
using System.Net;

using BookShopSystem.Data.Interfaces;
using BookShopSystem.Server.Api.DTOs.ViewModels;
using BookShopSystem.Server.Api.DTOs.InputModels;
using BookShopSystem.Models;

namespace BookShopSystem.Server.Api.Controllers
{
    public class AuthorsController : ApiController
    {
        private IBookShopContext context;

        public AuthorsController(IBookShopContext context)
        {
            this.context = context;
        }

        // GET api/authors/{id}
        public IHttpActionResult GetAuthorById(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var author = this.context.Authors
                .Include(x => x.Books)
                .Where(x => x.Id == id)
                .Select(AuthorViewModel.MapToViewModel)
                .FirstOrDefault();

            if (author == null)
            {
                return Content(HttpStatusCode.NotFound, 
                    string.Format("No author with id {0} found", id));
            }

            return this.Ok(author);
        }

        // POST api/authors
        public IHttpActionResult Post(AuthorInputModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAuthor = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName 
            };

            this.context.Authors.Add(newAuthor);
            this.context.SaveChanges();

            return this.Ok();
        }

        // GET api/authors/{id}/books
        [Route("api/authors/{id:int}/books")]
        public IHttpActionResult GetBooksByAuthor(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var authorBooks = this.context.Books
                .Include(x => x.Author)
                .Include(x => x.Categories)
                .Where(x => x.Author.Id == id)
                .Select(BookViewModel.MapToViewModel)
                .ToList();

            if (authorBooks == null)
            {
                return Content(HttpStatusCode.NotFound,
                    string.Format("No author with id {0} found", id));
            }

            return this.Ok(authorBooks);
        }
    }
}
