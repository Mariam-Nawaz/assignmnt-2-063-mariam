using System.ComponentModel.DataAnnotations;

namespace assignmnt_2_063_mariam.Models
{
    public class user
    {
        [Key]
        public string email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phn { get; set; }
     
    }
}
