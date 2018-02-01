using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Enitities;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class CamerasService : Service
    {
        public void Create(AddCameraBm camera, User user)
        {
            Camera model = Mapper.Map<AddCameraBm, Camera>(camera);
            User currentUser = this.Context.Users.Find(user.Id);
            currentUser.Cameras.Add(model);
            this.Context.SaveChanges();
        }

        public EditCameraVm GetEditVm(int? id, User user)
        {
            User currentUser = this.Context.Users.Find(user.Id);
            Camera camera = currentUser.Cameras.FirstOrDefault(camera1 => camera1.Id == id);
            if (camera == null)
            {
                return null;
            }

            EditCameraVm vm = Mapper.Map<Camera, EditCameraVm>(camera);
            return vm;
        }

        public void Edit(EditCameraBm bind, User user)
        {
            User currentUser = this.Context.Users.Find(user.Id);
            Camera camera = Mapper.Map<EditCameraBm, Camera>(bind);
            this.Context.Entry(camera).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public DeleteCameraVm GetDeleteVm(int? id, User user)
        {
            User currentUser = this.Context.Users.Find(user.Id);
            Camera camera = currentUser.Cameras.FirstOrDefault(camera1 => camera1.Id == id);
            if (camera == null)
            {
                return null;
            }

            DeleteCameraVm vm = Mapper.Map<Camera, DeleteCameraVm>(camera);
            return vm;
        }

        public void Delete(int id)
        {
            Camera entityToDelete = this.Context.Cameras.Find(id);
            this.Context.Cameras.Remove(entityToDelete);
            this.Context.SaveChanges();
        }

        public DetailsCameraVm GetDetailsVm(int? id, User user)
        {
            User currentUser = null;
            if (user != null)
            {
                currentUser = this.Context.Users.Find(user.Id);
            }
            Camera camera = this.Context.Cameras.FirstOrDefault(camera1 => camera1.Id == id);
            if (camera == null)
            {
                return null;
            }

            DetailsCameraVm vm = Mapper.Map<Camera, DetailsCameraVm>(camera);
            vm.Username = currentUser?.Username;
            return vm;
        }

        public IEnumerable<ShortCameraVm> GetAllCameras()
        {
            IEnumerable<Camera> cameras = this.Context.Cameras;
            IEnumerable<ShortCameraVm> vms = Mapper.Map<IEnumerable<Camera>, IEnumerable<ShortCameraVm>>(cameras);
            return vms;
        }
    }
}
