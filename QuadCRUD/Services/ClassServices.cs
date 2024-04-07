using QuadCRUD.AppDbContext;
using QuadCRUD.Interfaces;
using QuadCRUD.Models;
using QuadCRUD.Repository.Base;

namespace QuadCRUD.Services
{
    public class ClassServices : EfBaseRepository<Class>,IClassService
    {
        public ClassServices(ApplicationDbContext context):base(context)
        {
            
        }

        public Task<Class> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
