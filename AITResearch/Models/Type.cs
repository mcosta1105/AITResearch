using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Type
    {
        //Table primary key
        [Key]
        [Column(TypeName = "Integer(10)")]
        public int TID { get; set; }

        //Table fields
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Name { get; set; }

        //Table relationship
        public List<Question> Questions { get; set; }

    }
}