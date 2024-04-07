using Microsoft.AspNetCore.Identity;
using QuadCRUD.Models.Base;

namespace QuadCRUD.Models
{
    public class Class:Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator List<object>(Class v)
        {
            throw new NotImplementedException();
        }
    }
}
