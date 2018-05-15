namespace AITResearch.Migrations.AitrDbContext
{
    using System.Data.Entity.Migrations;

    public partial class PopulateStaffTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Staff (Username, Password) VALUES ('maycon', 'maycon123') ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Staff WHERE Username IN ('maycon')");
        }
    }
}
