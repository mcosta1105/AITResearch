using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Staff
    {
        //Table primary key
        [Key]
        [Column(TypeName = "Varchar(100)")]
        public string Username { get; set; }

        //Table field
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Password { get; set; }

    }
}