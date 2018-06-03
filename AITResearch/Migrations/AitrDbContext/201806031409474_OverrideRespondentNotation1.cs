namespace AITResearch.Migrations.AitrDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideRespondentNotation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Respondent", "IP_Address", c => c.String(nullable: false, maxLength: 45, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Respondent", "IP_Address", c => c.String(nullable: false, maxLength: 15, unicode: false));
        }
    }
}
