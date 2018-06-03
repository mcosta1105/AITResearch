using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AITResearch.ViewModels
{
    public class RegisterFormViewModel
    {
        [Required(ErrorMessage ="Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DoB { get; set; }

        public string Phone { get; set; }
    }
}