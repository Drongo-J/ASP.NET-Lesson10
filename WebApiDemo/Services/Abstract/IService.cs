namespace WebApiDemo.Services.Abstract
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T Get(int id);
    }
}
