using System.ComponentModel;

namespace AITResearch.ViewModels
{
    public class RegisterFormViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public string DoB { get; set; }
        public string Phone { get; set; }
    }
}