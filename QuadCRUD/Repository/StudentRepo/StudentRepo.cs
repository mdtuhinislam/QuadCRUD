using QuadCRUD.AppDbContext;
using QuadCRUD.Interfaces;
using QuadCRUD.Models;
using QuadCRUD.Repository.Base;

namespace QuadCRUD.Repository.StudentRepo
{
    public class StudentRepo : EfBaseRepository<Student>
    {
        private readonly ApplicationDbContext _context;
        public StudentRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
