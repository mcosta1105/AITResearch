namespace AITResearch.Migrations.AitrDbContext
{
    using System.Data.Entity.Migrations;

    public partial class PopulateQuestionOptionsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Male', 2)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Female', 2)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('18 - 24', 3)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('25 - 24', 3)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('35 - 44', 3)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('45 - 54', 3)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('55 - 64', 3)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('65 or Older', 3)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Australian Capital Territory', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('New South Wales', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Northern Territory', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Queensland', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('South Australia', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Tasmania', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Victoria', 4)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Western Australia', 4)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Commonwealth', 7, 9)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Westpac', 7, 9)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('ANZ', 7, 9)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Nab', 7)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Citi Bank', 7)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Internet Banking', 9)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Home Loan', 9)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Credit Card', 9)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Share Investment', 9)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Mortgage Loan', 9)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('The Canberra Times', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('The Daily Telegraph', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('The Sydney Morning Herald', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Herald Sun', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('The West Australian', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Courier Mail', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('The Advertiser', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('The Mercury', 8, 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Northern Territory News', 8, 10)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('None', 8)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Property', 10)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Sport', 10, 11)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Financial', 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Entertainment', 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Lifestyle', 10)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID, NextQuestion) VALUES ('Travel', 10, 12)");

            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Politics', 10)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('AFL', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Football', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Cricket', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Racing', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Motosport', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Basketball', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Tennis', 11)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Australia', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Europe', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Pacific', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('North America', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('South America', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Asia', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Middle East', 12)");
            Sql("INSERT INTO QuestionOptions (Value, Question_QID) VALUES ('Africa', 12)");

        }
        
        public override void Down()
        {
           
        }
    }
}
