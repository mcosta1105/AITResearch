using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Option
    {
        //Table primary key
        [Key]
        [Column(TypeName = "Integer(10)")]
        public int OID { get; set; }
        
        //Table fields
        [Required]
        [Column(TypeName = "Varchar(255)")]
        public string Value { get; set; }

        [Column(TypeName = "Integer(10)")]
        public int NextQuestion { get; set; }

        //Table foreign key
        public int Question_QID { get; set; }
        
        //Table relationship
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }

    }
}