using QuadCRUD.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuadCRUD.Models
{
    public class Student:Audit
    {
        public Student()
        {
            Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }

    }
}
