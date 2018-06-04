using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AITResearch.ViewModels
{
    public class RegisterFormViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DoB { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}