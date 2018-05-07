using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Respondent
    {
        //Table primary key
        [Key]
        [Column(TypeName = "Integer(10)")]
        public int RID { get; set; }

        //Table fields
        [Column(TypeName = "Varchar(15)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "Varchar(15)")]
        public string IP_Address { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DoB { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string LastName { get; set; }

        //Table relationship
        public List<Answer> RespondentAnswers { get; set; }
    }
}