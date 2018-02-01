namespace LinkedIn.Web.ModelBinders
{
    using System.Web.Mvc;

    using LinkedIn.Data.Repositories;
    using LinkedIn.Models;

    public class EntityModelBinder<T> : IModelBinder
        where T : class, IEntity
    {
        private readonly IRepository<T> repository;

        public EntityModelBinder(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");
            var id = int.Parse(value.AttemptedValue);
            var entity = this.repository.Find(id);
            return entity;
        }
    }
}