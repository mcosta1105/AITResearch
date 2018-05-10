using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AITResearch.Models
{
    [Table("QuestionOptions")]
    public class Option
    {
        //Table primary key
        [Key]
        public int OID { get; set; }
        
        //Table fields
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Value { get; set; }

        
        public int? NextQuestion { get; set; }

        //Table foreign key
        [ForeignKey("Question")]
        public int Question_QID { get; set; }

        
        //Table relationship
        public Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

    }
}