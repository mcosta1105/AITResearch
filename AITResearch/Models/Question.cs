using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AITResearch.Models
{
    [Table("Question")]
    public class Question
    {
        //Table primary key
        [Key]
        public int QID { get; set; }

        //Table fields
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Text { get; set; }

        
        public int? Order { get; set; }

        //Foreign Key
        [ForeignKey("Type")]
        public int Type_TID { get; set; }

        //Table relationship
        public Type Type { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}