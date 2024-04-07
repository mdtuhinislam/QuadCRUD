using Microsoft.EntityFrameworkCore;
using QuadCRUD.Models;

namespace QuadCRUD.AppDbContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
