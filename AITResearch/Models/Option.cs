using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Option
    {
        public int OID { get; set; }
        public string Value { get; set; }
        public int NextQuestion { get; set; }
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }

    }
}