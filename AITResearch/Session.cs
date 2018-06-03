using AITResearch.Models;
using System.Collections.Generic;
using System.Web;
namespace AITResearch
{
    public class AppSession
    {
        //Sessions name
        const string QuestionNumber = "QuestionNumber";
        const string FollowUp = "FollowUp";
        const string Respondent = "Respondent";
        const string Answers = "Answer";


        public static int GetQuestionNumber()
        {
            if (HttpContext.Current.Session[QuestionNumber] == null)
            {
                HttpContext.Current.Session[QuestionNumber] = 1;
            }
                

            return (int)HttpContext.Current.Session[QuestionNumber];
        }

        public static void IncrementQuestionNumber()
        {
            int q = GetQuestionNumber();
            q++;
            HttpContext.Current.Session[QuestionNumber] = q;
        }        

        public static void AddFollowUpQuestion(int i)
        {
            List<int> questions = new List<int>();
            if (GetFollowUpQuestions() != null)
            {
                questions = GetFollowUpQuestions();
            }            
            questions.Add(i);

            SetFollowUpQuestions(questions);
        }

        public static void RemoveFollowUpQuestion(int i)
        {
            List<int> questions = new List<int>();            
            questions = GetFollowUpQuestions();
            questions.Remove(i);
            SetFollowUpQuestions(questions);
        }

        public static void SetFollowUpQuestions(List<int> followUpQuestions)
        {
            HttpContext.Current.Session[FollowUp] = followUpQuestions;
        }

        public static List<int> GetFollowUpQuestions()
        { 
            return (List<int>)HttpContext.Current.Session[FollowUp];
        }

        //Store current respondent Id in Session
        public static void SetRespondent(Respondent respondent)
        {
            HttpContext.Current.Session[Respondent] = respondent;
        }

        //Get current respondent in Session
        public static Respondent GetRespondent()
        {
            return (Respondent)HttpContext.Current.Session[Respondent];
        }


        //Set answers in Session
        public static void SetAnswers(List<Answer> answers)
        {
            HttpContext.Current.Session[Answers] = answers;
        }

        //Get answers stored in Session
        public static List<Answer> GetAnswers()
        {
            return (List<Answer>)HttpContext.Current.Session[Answers];
        }

        //Add answer to list and store in session
        public static void AddAnswer(Answer answer)
        {
            List<Answer> answers = GetAnswers();
            answers.Add(answer);
            SetAnswers(answers);
        }



        //Cleans Session
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}