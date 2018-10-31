using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AITResearch.ViewModels
{
    public class RegisterFormViewModel
    {
        [Required]
        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First Name is maximum 50 characteres")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Last Name is maximum 50 characteres")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Date of Birth must be a valid date")]
        public DateTime DoB { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "It must be a valid phone number")]
        [StringLength(15, ErrorMessage = "Phone number maximum length is 15 digits")]
        public string Phone { get; set; }
    }
}