using Microsoft.AspNetCore.Mvc;

namespace SimpleGameApi.Models.Domain.Contracts.Base
{
    public interface IGenericActionController<T, Y>
        where T : class
    {
        ActionResult Add(T entity);
        ActionResult Update(T entity);
        ActionResult Delete(Y id);
        ActionResult Get(Y id);
        ActionResult GetAll();
    }
}
