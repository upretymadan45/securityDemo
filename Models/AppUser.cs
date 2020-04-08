using System.ComponentModel.DataAnnotations;

namespace sqlinj.Models
{
    public class AppUser{
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}