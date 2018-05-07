using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Question
    {
        //Table primary key
        [Key]
        [Column(TypeName = "Integer(10)")]
        public int QID { get; set; }

        //Table fields
        [Required]
        [Column(TypeName = "Varchar(255)")]
        public string Text { get; set; }

        [Column(TypeName = "Integer(10)")]
        public int Order { get; set; }

        //Foreign Key
        public int Type_TID { get; set; }

        //Table relationship
        public Type Type { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Option> Options { get; set; }
    }
}