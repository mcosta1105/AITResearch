using System.ComponentModel.DataAnnotations;

namespace AITResearch.ViewModels
{
    public class LoginFormViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}