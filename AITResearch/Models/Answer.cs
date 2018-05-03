using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Answer
    {
        public int AID { get; set; }
        public string Text { get; set; }
        public int Respondent_RID { get; set; }
        public int Option_OID { get; set; }
        public int Question_QID { get; set; }
        public Respondent Respondent { get; set; }
        public Option Option { get; set; }
        public Question Question { get; set; }
        
    }
}