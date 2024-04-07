using QuadCRUD.Models;

namespace QuadCRUD.Interfaces
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetAllWithAssociateClasses();
        Task<Student> GetByIdWithAssociateClasses(Guid id);
    }
}
