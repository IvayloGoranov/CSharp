using System.Web.Http;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System;

using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Server.Api.Models;

namespace OnlineShop.Server.Api.Controllers
{
    [Authorize]
    public class AdsController : BaseApiController
    {
        public AdsController(IOnlineShopContext data)
            : base(data)
        {
        }

        // GET api/ads
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var allAds = this.Data.Ads
                .Include(x => x.Type)
                .Include(x => x.Owner)
                .Include(x => x.Categories)
                .Where(x => x.Status == AdStatus.Open)
                .OrderBy(x => x.Type.Name)
                .ThenBy(x => x.PostedOn)
                .Select(AdViewModel.MapToViewModel)
                .ToList();

            return this.Ok(allAds);
        }

        // POST api/ads
        public IHttpActionResult Post(CreateAdBindingModel createAdModel)
        {
            //var userId = this.User.Identity.GetUserId();
            //if (userId == null)
            //{
            //    this.Unauthorized();
            //}

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (createAdModel.Categories.Count() < 1 ||
                createAdModel.Categories.Count() > 3)
            {
                return this.BadRequest("Categories count should be between 1 and 3");
            }

            var newAd = createAdModel.CreateAd();
            var type = this.Data.AdTypes.Find(createAdModel.TypeId);
            if (type == null)
            {
                return this.BadRequest(
                    string.Format("No type with id {0} found", createAdModel.TypeId));
            }

            newAd.Type = type;
            foreach (var categoryId in createAdModel.Categories)
            {
                var category = this.Data.Categories.Find(categoryId);
                if (category == null)
                {
                    return this.BadRequest(
                        string.Format("No category with id {0} found", categoryId));
                }

                newAd.Categories.Add(category);
            }

            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);
            newAd.Owner = user;

            this.Data.Ads.Add(newAd);
            this.Data.SaveChanges();

            return this.Ok();
        }

        // PUT api/ads/{id}/close 
        [HttpPut]
        [Route("api/ads/{id:int}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            var adToClose = this.Data.Ads.Find(id);
            if (adToClose == null)
            {
                return this.BadRequest(string.Format("No ad with id {0} found", id));
            }

            string userId = this.User.Identity.GetUserId();
            if (adToClose.OwnerId !=userId )
            {
                this.Unauthorized();
            }

            adToClose.Status = AdStatus.Closed;
            adToClose.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
