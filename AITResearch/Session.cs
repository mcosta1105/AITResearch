﻿using System.Collections.Generic;
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
            List<int> questions = GetFollowUpQuestions();
            questions.Add(i);
            SetFollowUpQuestions(questions);
        }

        public static void RemoveFollowUpQuestion(int i)
        {
            List<int> questions = GetFollowUpQuestions();
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


    }
}