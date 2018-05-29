namespace AITResearch.Migrations.AitrDbContext
{
    using System.Data.Entity.Migrations;

    public partial class PopulateQuestionsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What is your email?', 1, 1) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What is your gender?', 2, 2) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What is  your age range?', 2, 3) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What State or Territory of Autralia do you live?', 2, 4) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What suburb do you live?', 1, 5) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What is the post code of your address?', 1, 6) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What Banks do you use?', 3, 7) ");
            Sql("INSERT INTO Question (Text, Type_TID, QuestionOrder) VALUES ('What newspapers do you read?', 3, 8) ");

            Sql("INSERT INTO Question (Text, Type_TID) VALUES ('What special services do you use at your Bank?', 3) ");
            Sql("INSERT INTO Question (Text, Type_TID) VALUES ('What are the news sections you have interest in reading?', 3) ");
            Sql("INSERT INTO Question (Text, Type_TID) VALUES ('What sports are you interested?', 3) ");
            Sql("INSERT INTO Question (Text, Type_TID) VALUES ('What travel destinations would you be interested?', 3) ");
        }
        
        public override void Down()
        {
        }
    }
}
