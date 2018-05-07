using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Answer
    {
        //Table primary key
        [Key]
        [Column(TypeName = "Integer(10)")]
        public int AID { get; set; }

        //Table fields
        [Column(TypeName = "Varchar(255)")]
        public string Text { get; set; }

        //Table foreign keys
        public int Respondent_RID { get; set; }
        public int? Option_OID { get; set; }
        public int Question_QID { get; set; }

        //Table relationship
        public Respondent Respondent { get; set; }
        public Option Option { get; set; }
        public Question Question { get; set; }
        
    }
}