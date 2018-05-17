namespace AITResearch.Migrations.AitrDbContext
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Type (Name) VALUES ('Text')");
            Sql("INSERT INTO Type (Name) VALUES ('Checkbox')");
            Sql("INSERT INTO Type (Name) VALUES ('Multiple')");

        }

        public override void Down()
        {
        }
    }
}
