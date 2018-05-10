using System.Data.Entity;

namespace AITResearch.Models
{
    public class AitrDbContext: DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Type> Types { get; set; }

        public AitrDbContext()
            : base("AITRConnection")
        {
        }
    }
}