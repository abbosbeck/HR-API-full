using System.ComponentModel.DataAnnotations;

namespace Post2.Modules
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
