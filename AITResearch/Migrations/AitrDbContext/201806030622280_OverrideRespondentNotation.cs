namespace AITResearch.Migrations.AitrDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideRespondentNotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Respondent", "DoB", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Respondent", "DoB", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
