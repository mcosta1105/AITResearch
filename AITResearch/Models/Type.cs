using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch.Models
{
    public class Type
    {
        public int TID { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

    }
}