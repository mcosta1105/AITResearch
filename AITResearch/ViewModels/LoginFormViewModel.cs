using System.ComponentModel.DataAnnotations;

namespace AITResearch.ViewModels
{
    public class LoginFormViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email format")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}