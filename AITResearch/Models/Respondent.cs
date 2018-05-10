using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AITResearch.Models
{
    [Table("Respondent")]
    public class Respondent
    {
        //Table primary key
        [Key]
        public int RID { get; set; }

        //Table fields
        [MaxLength(15)]
        [Column(TypeName = "VARCHAR")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "VARCHAR")]
        public string IP_Address { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DoB { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string LastName { get; set; }

        //Table relationship
        public virtual ICollection<Answer> RespondentAnswers { get; set; }
    }
}