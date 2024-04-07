using System.ComponentModel.DataAnnotations.Schema;

namespace QuadCRUD.Models.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public List<Class> Classes { get; set; }
    }
}
