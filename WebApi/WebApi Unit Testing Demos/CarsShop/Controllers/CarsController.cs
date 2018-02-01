using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarsShop.Models;
using CarsShop.Models.BindingModels;
using CarsShop.Models.Entities;
using CarsShop.Models.ViewModels;
using CarsShop.Services.Implementations;
using CarsShop.Services.Interfaces;

namespace CarsShop.Controllers
{
    public class CarsController : ApiController
    {
        private ICarsService service;
               
        public CarsController(ICarsService service)
        {
            this.service = service;
        }

        public IHttpActionResult Get()
        {
            IEnumerable<CarVm> vm = this.service.GetAllCars();
            return this.Ok(vm);
        }

        // GET: api/Cars/5
        public IHttpActionResult Get(int id)
        {
            if (!this.service.ContainsCar(id))
            {
                return this.NotFound();
            }
            CarVm wanted = this.service.GetCarById(id);

            return this.Ok(wanted);
        }

        // POST: api/Cars
        public IHttpActionResult Post(CarBm car)
        {
            if (!this.ModelState.IsValid)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

            this.service.Add(car);
            return this.StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Cars/5
        public IHttpActionResult Put(int id, CarBm bind)
        {   
            if (!this.service.ContainsCar(id))
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            if (!this.ModelState.IsValid)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

            this.service.Edit(id, bind);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Cars/5
        public IHttpActionResult Delete(int id)
        {   
            if (!this.service.ContainsCar(id))
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            this.service.Delete(id);
            return this.Ok();
        }
    }
}
