using QuadCRUD.Models;

namespace QuadCRUD.Interfaces
{
    public interface IClassService
    {
        Task<bool> Add(Class entity);

        Task<ICollection<Class>> GetAll();

        Task<Class> GetById(int id);

        Task<bool> UpdateAsync(Class entity);
        bool Remove(Class entity);
    }
}
