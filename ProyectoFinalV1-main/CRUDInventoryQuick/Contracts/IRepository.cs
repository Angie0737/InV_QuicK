using CRUDInventoryQuick.Models;

namespace CRUDInventoryQuick.Contracts
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T t);
        Task Delete(T t);
        Task<int> Update(T t);
        Task Save();
    }
}
