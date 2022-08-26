using System.ComponentModel.DataAnnotations;

namespace Post2.Modules
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
