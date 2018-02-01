using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using Fruits.Data.Interfaces;
using Fruits.Models;
using Fruits.Models.Enums;
using Fruits.Web.InputModels.Fruits;
using Fruits.Web.ViewModels.Fruits;

namespace Fruits.Web.Controllers
{
    [Authorize(Roles = "FruitClient, FruitAdmin")]
    public class FruitsController : Controller
    {
        private IRepository<Fruit> fruitsRepository;

        public FruitsController(IRepository<Fruit> fruitsRepository)
        {
            this.fruitsRepository = fruitsRepository;
        }

        public IActionResult Index(Importance? filterValue)
        {
            this.ViewBag.Filter = filterValue;

            IEnumerable<FruitViewModel> fruits = null;
            if (filterValue != null)
            {
                fruits = this.fruitsRepository.GetAll()
                                              .Where(x => x.Importance > filterValue)                              
                                              .Select(FruitViewModel.MapToDTO)
                                              .ToList();
            }
            else
            {
                fruits = this.fruitsRepository.GetAll()
                                              .Select(FruitViewModel.MapToDTO)
                                              .ToList();
            }

            return this.View(fruits);
        }

        // GET: Fruits/Add
        [Authorize(Roles = "FruitAdmin")]
        public IActionResult Add()
        {
            return this.View();
        }

        // POST: Fruits/Add
        [Authorize(Roles = "FruitAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(FruitInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newFruit = model.CreateFruit();
                await this.fruitsRepository.Add(newFruit);

                this.TempData["Message"] = "Fruit added";

                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        // GET: Fruits/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                this.TempData["Message"] = "Please select a fruit to edit";

                return this.RedirectToAction("Index");
            }

            var fruit = await this.fruitsRepository.Find((int)id);
            var editModel = FruitInputModel.FromModel(fruit);

            this.ViewBag.FruitId = id;

            return this.View(editModel);
        }

        // POST: Fruits/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, FruitInputModel model)
        {
            if (id == null)
            {
                return this.StatusCode(400);
            }

            if (this.ModelState.IsValid)
            {
                var fruit = await this.fruitsRepository.Find((int)id);
                model.UpdateFruit(fruit);
                await this.fruitsRepository.Update(fruit);

                this.TempData["Message"] = "Fruit edited.";

                return this.RedirectToAction("Index");
            }

            this.ViewBag.FruitId = id;

            return this.View(model);
        }

        // POST: Fruits/Delete/id
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.StatusCode(400);
            }

            await this.fruitsRepository.Delete((int)id);

            return this.StatusCode(200);
        }
    }
}