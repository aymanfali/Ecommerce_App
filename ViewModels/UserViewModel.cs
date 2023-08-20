using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
