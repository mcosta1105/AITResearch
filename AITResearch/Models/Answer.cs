using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AITResearch.Models
{
    [Table("Answer")]
    public class Answer
    {
        //Table primary key
        [Key]
        public int AID { get; set; }

        //Table fields
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Text { get; set; }

        //Table foreign keys
        [ForeignKey("Respondent")]
        public int Respondent_RID { get; set; }

        [ForeignKey("Option")]
        public int? Option_OID { get; set; }

        [ForeignKey("Question")]
        public int Question_QID { get; set; }

        //Table relationship
        public Respondent Respondent { get; set; }
        public Option Option { get; set; }
        public Question Question { get; set; }
        
    }
}