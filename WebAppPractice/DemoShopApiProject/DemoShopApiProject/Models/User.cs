using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoShopApiProject.Models
{
    public class User
    {
        

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public String Email { get; set; }
        public string City { get; set; }
    }
}
