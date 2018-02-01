using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels.Suppliers;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Suppliers;

namespace CarDealer.Services
{
    public class SuppliersService : Service
    {
        public IEnumerable<SupplierVm> GetAllSuppliersByType(string type)
        {
            IEnumerable<Supplier> suppliersWanted = this.GetSupplierModelsByType(type);

            IEnumerable<SupplierVm> viewModels =
                Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierVm>>(suppliersWanted);

            return viewModels;
        }

        public IEnumerable<SupplierAllVm> GetAllSuppliersByTypeForUsers(string type)
        {
            IEnumerable<Supplier> suppliersWanted = this.GetSupplierModelsByType(type);

            IEnumerable<SupplierAllVm> viewModels =
               Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierAllVm>>(suppliersWanted);

            return viewModels;
        }

        private IEnumerable<Supplier> GetSupplierModelsByType(string type)
        {
            IEnumerable<Supplier> suppliersWanted;
            if (type == null)
            {
                suppliersWanted = this.Context.Suppliers;
            }
            else if (type.ToLower() == "local")
            {
                suppliersWanted = this.Context.Suppliers.Where(supplier => !supplier.IsImporter);
            }
            else if (type.ToLower() == "importers")
            {
                suppliersWanted = this.Context.Suppliers.Where(supplier => supplier.IsImporter);
            }
            else
            {
                throw new ArgumentException("Invalid argument for the type of the supplier!");
            }

            return suppliersWanted;
        }

        public void AddSupplier(AddSupplierBm bind, int userId)
        {
            Supplier supplier = Mapper.Map<AddSupplierBm, Supplier>(bind);
            this.Context.Suppliers.Add(supplier);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Add, "suppliers");
        }

        private void AddLog(int userId, OperationLog operation, string modifiedTable)
        {
            User loggedUser = this.Context.Users.Find(userId);
            Log log = new Log()
            {
                User = loggedUser,
                ModifiedAt = DateTime.Now,
                ModifiedTableName = modifiedTable,
                Operation = operation
            };

            this.Context.Logs.Add(log);
            this.Context.SaveChanges();
        }

        public EditSupplierVm GetEditSupplierVm(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            EditSupplierVm vm = Mapper.Map<Supplier, EditSupplierVm>(supplier);
            return vm;
        }

        public void EditSupplier(EditSupplierBm bind, int userId)
        {
            Supplier model = this.Context.Suppliers.Find(bind.Id);
            model.IsImporter = bind.IsImporter == "on";
            model.Name = bind.Name;
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Edit, "suppliers");
        }

        public DeleteSuplierVm GetDeleteSupplierVm(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            DeleteSuplierVm vm = Mapper.Map<Supplier, DeleteSuplierVm>(supplier);
            return vm;
        }

        public void DeleteSupplier(DeleteSupplierBm bind, int userId)
        {
            Supplier supplier = this.Context.Suppliers.Find(bind.Id);
            this.Context.Suppliers.Remove(supplier);
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Delete, "suppliers");
        }
    }
}
