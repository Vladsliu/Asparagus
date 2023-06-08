using System.ComponentModel.DataAnnotations;

namespace Asparagus2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public int CountEat { get; set; }
        public DateTime DateTime { get; set; }
    }
}
