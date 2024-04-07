using Microsoft.EntityFrameworkCore;
using QuadCRUD.AppDbContext;
using QuadCRUD.Interfaces;
using QuadCRUD.Models;

namespace QuadCRUD.Repository.Base
{
    public class StudentRepo : EfBaseRepository<Student>, IStudentRepo
    {
        private readonly ApplicationDbContext _context;
        public StudentRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllWithAssociateClasses()
        {
            return await _context.Students.Include("Class").ToListAsync();
            
        }

        public async Task<Student> GetByIdWithAssociateClasses(Guid id)
        {
            return await _context.Students.Include("Class").FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
