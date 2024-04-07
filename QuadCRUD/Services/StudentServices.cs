using Microsoft.EntityFrameworkCore;
using QuadCRUD.AppDbContext;
using QuadCRUD.Interfaces;
using QuadCRUD.Models;
using QuadCRUD.Repository.Base;

namespace QuadCRUD.Services
{
    public class StudentServices:EfBaseRepository<Student>,IStudentServices, IStudentRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentRepo _studentRepo;
        public StudentServices(ApplicationDbContext context, IStudentRepo studentRepo) :base(context)
        {
            _context = context;
            _studentRepo = studentRepo;
        }

        public async Task<IEnumerable<Student>> GetAllWithAssociateClasses()
        {
            return await _studentRepo.GetAllWithAssociateClasses();
        }

        public async Task<Student> GetByIdWithAssociateClasses(Guid id)
        {
            return await _studentRepo.GetByIdWithAssociateClasses(id);
        }
        public override async Task<bool> UpdateAsync(Student entity)
        {
            entity.ModificationDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }


    }
}
