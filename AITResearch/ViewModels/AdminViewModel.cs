using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AITResearch.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        [DisplayName("Search")]
        public string SearchInput { get; set; }

        public List<RespondentRowModel> Respondents { get; set; }

    }

    public class RespondentRowModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string AgeRange { get; set; }

    }
}