namespace AITResearch.Migrations.AitrDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 255, unicode: false),
                        Respondent_RID = c.Int(nullable: false),
                        Option_OID = c.Int(),
                        Question_QID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AID)
                .ForeignKey("dbo.QuestionOptions", t => t.Option_OID)
                .ForeignKey("dbo.Question", t => t.Question_QID, cascadeDelete: true)
                .ForeignKey("dbo.Respondent", t => t.Respondent_RID, cascadeDelete: true)
                .Index(t => t.Respondent_RID)
                .Index(t => t.Option_OID)
                .Index(t => t.Question_QID);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        OID = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 255, unicode: false),
                        NextQuestion = c.Int(),
                        Question_QID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OID)
                .ForeignKey("dbo.Question", t => t.Question_QID, cascadeDelete: true)
                .Index(t => t.Question_QID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 255, unicode: false),
                        Order = c.Int(),
                        Type_TID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QID)
                .ForeignKey("dbo.Type", t => t.Type_TID, cascadeDelete: true)
                .Index(t => t.Type_TID);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        TID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TID);
            
            CreateTable(
                "dbo.Respondent",
                c => new
                    {
                        RID = c.Int(nullable: false, identity: true),
                        Phone = c.String(maxLength: 15, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        IP_Address = c.String(nullable: false, maxLength: 15, unicode: false),
                        DoB = c.DateTime(nullable: false, storeType: "date"),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.RID);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "Respondent_RID", "dbo.Respondent");
            DropForeignKey("dbo.Answer", "Question_QID", "dbo.Question");
            DropForeignKey("dbo.Answer", "Option_OID", "dbo.QuestionOptions");
            DropForeignKey("dbo.QuestionOptions", "Question_QID", "dbo.Question");
            DropForeignKey("dbo.Question", "Type_TID", "dbo.Type");
            DropIndex("dbo.Question", new[] { "Type_TID" });
            DropIndex("dbo.QuestionOptions", new[] { "Question_QID" });
            DropIndex("dbo.Answer", new[] { "Question_QID" });
            DropIndex("dbo.Answer", new[] { "Option_OID" });
            DropIndex("dbo.Answer", new[] { "Respondent_RID" });
            DropTable("dbo.Staff");
            DropTable("dbo.Respondent");
            DropTable("dbo.Type");
            DropTable("dbo.Question");
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.Answer");
        }
    }
}
