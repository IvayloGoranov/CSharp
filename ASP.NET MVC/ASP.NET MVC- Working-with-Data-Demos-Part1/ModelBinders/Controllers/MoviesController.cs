using System;
using System.Linq;
using ModelBinders.Models;

namespace ModelBinders.Controllers
{
    using System.Web.Mvc;
using System.Collections.Generic;
    using System.Text;

    public class MoviesController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddWithParams(string title, string review, int lengthInMinutes, DateTime releaseDate)
        {
            return this.Content(string.Format("Title: {0}, Review: {1}, Length: {2}, Release: {3}", 
                title, 
                review, 
                lengthInMinutes, 
                releaseDate));
        }

        [HttpPost]
        public ActionResult AddWithModel(MovieInputModel model)
        {
            return this.Content(string.Format("Title: {0}, Review: {1}, Length: {2}, Release: {3}",
                model.Title,
                model.Review,
                model.LengthInMinutes,
                model.ReleaseDate));
        }

        public ActionResult AddNested()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddNestedWithModel(MovieDetailedInputModel model)
        {
            return this.Content(string.Format("Title: {0}, Review: {1}, Length: {2}, Release: {3}, Town: {4}, Country: {5}",
                model.Title,
                model.Review,
                model.LengthInMinutes,
                model.ReleaseDate,
                model.Address.Town,
                model.Address.Country));
        }

        public ActionResult AddCollection()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddCollection(IEnumerable<string> values)
        {
            var allValues = string.Join(", ", values);


            return this.Content(allValues);
        }

        public ActionResult AddCollectionOfMovies()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddCollectionOfMovies(IEnumerable<MovieInputModel> model)
        {
            var movies = string.Empty;
            foreach (var movie in model)
            {
                movies += string.Format("Title: {0}, Review: {1}, Length: {2}, Release: {3}",
                    movie.Title,
                    movie.Review,
                    movie.LengthInMinutes,
                    movie.ReleaseDate);
                movies += "<br/>";
            }

            return this.Content(movies, "text/html");
        }
    }
}