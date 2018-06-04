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

        /*
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }*/
    }
}