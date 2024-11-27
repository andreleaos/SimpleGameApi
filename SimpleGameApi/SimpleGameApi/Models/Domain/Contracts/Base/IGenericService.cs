namespace SimpleGameApi.Models.Domain.Contracts.Base;
public interface IGenericService<T, Y>
    where T : class
{
    void Add(T entity);
    bool Update(T entity);
    bool Delete(Y id);
    T Get(Y id);
    List<T> GetAll();
}
