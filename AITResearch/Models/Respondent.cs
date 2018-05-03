using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Respondent
    {
        public int RID { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string IP_Address { get; set; }
        public DateTime DoB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Answer> RespondentAnswers { get; set; }
    }
}