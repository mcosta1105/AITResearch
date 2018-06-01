using System.Collections.Generic;
using System.Web;
namespace AITResearch
{
    public class AppSession
    {
        //Sessions
        const string QuestionNumber = "QuestionNumber";
        const string FollowUp = "FollowUp";


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

        }

        public static void SetFollowUpQuestion(List<int> followUpQuestions)
        {
            HttpContext.Current.Session[FollowUp] = followUpQuestions;
        }        
       
    }
}