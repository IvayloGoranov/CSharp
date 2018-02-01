using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Enitities;
using CameraBazaar.Models.ViewModels;
using CameraBazaar.Services;
using AuthenticationManager = CameraBazaar.Web.Security.AuthenticationManager;

namespace CameraBazaar.Web.Controllers
{
    [RoutePrefix("cameras")]             
    public class CamerasController : Controller
    {
        private CamerasService service;

        public CamerasController()
        {
            this.service = new CamerasService();
        }

        [HttpGet]
        [Route("all")]
        [Route("~/")]
        public ActionResult All()
        {
            IEnumerable<ShortCameraVm> vms = this.service.GetAllCameras();

            return this.View(vms);
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int? id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            DetailsCameraVm camera = this.service.GetDetailsVm(id, user);

            if (camera == null)
            {
                return HttpNotFound();
            }

            return View(camera);
        }

        [HttpGet, Route("create")]
        public ActionResult Create()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create([Bind(Include = "Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,LightMetering,Description,ImageUrl")] AddCameraBm camera)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (this.ModelState.IsValid)
            {
                User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
                this.service.Create(camera, user);
                return RedirectToAction("Profile", "Users");
            }
            AddCameraVm vm = Mapper.Map<AddCameraBm, AddCameraVm>(camera);
            return View(vm);
        }


        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            EditCameraVm vm = this.service.GetEditVm(id, user);

            if (vm == null)
            {
                return this.RedirectToAction("Profile", "Users");
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,LightMetering,Description,ImageUrl")] EditCameraBm camera)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (ModelState.IsValid)
            {
                User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
                this.service.Edit(camera, user);
                return this.RedirectToAction("Profile", "Users");
            }

            EditCameraVm vm = Mapper.Map<EditCameraBm, EditCameraVm>(camera);
            return View(vm);
        }

        // GET: Cameras/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            DeleteCameraVm vm = this.service.GetDeleteVm(id, user);
            if (vm == null)
            {
                return this.RedirectToAction("Profile", "Users");
            }

            return View(vm);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }

            this.service.Delete(id);
            return this.RedirectToAction("Profile", "Users");
        }
    }
}
