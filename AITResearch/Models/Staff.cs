using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AITResearch.Models
{
    [Table("Staff")]
    public class Staff
    {
        //Table primary key
        [Key]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }

        //Table field
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

    }
}