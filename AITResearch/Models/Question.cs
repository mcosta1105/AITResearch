using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Question
    {
        public int QID { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public Type Type { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Option> Options { get; set; }

    }
}