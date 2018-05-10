using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AITResearch.Models
{
    [Table("Type")]
    public class Type
    {
        //Table primary key
        [Key]
        public int TID { get; set; }

        //Table fields
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        //Table relationship
        public virtual ICollection<Question> Questions { get; set; }

    }
}