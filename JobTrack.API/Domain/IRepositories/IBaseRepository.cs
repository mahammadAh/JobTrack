namespace Domain.IRepositories;

public interface IBaseRepository<T>
{
    void Create(T entity);
    void Delete(Guid id);
    T Get(Guid id);
    List<T> GetAll();
    void Update(T entity);
}