using QuadCRUD.Models;

namespace QuadCRUD.Interfaces
{
    public interface IStudentServices
    {
        Task<bool> Add(Student entity);

        Task<ICollection<Student>> GetAll();

        Task<Student> GetById(Guid id);

        Task<bool> UpdateAsync(Student entity);
        bool Remove(Student entity);
        Task<IEnumerable<Student>> GetAllWithAssociateClasses();
        Task<Student> GetByIdWithAssociateClasses(Guid id);

    }
}
