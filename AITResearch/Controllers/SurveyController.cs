using AITResearch.Models;
using AITResearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AITResearch.Controllers
{
    public class SurveyController : Controller
    {
        

        //Declare DB Context
        private AitrDbContext _context;
        

        //Constructor
        public SurveyController()
        {
            //Instantiate DB Context
            _context = new AitrDbContext();

        }

        // GET: Survey
        [HttpGet]
        public ActionResult Survey()
        {
            
            var viewModel = new SurveyViewModel();

            //Verify if there is any followUp question in Session
            if (AppSession.GetFollowUpQuestions() == null || AppSession.GetFollowUpQuestions().Count() == 0)
            {
                //Return question by Order
                if(IsQuestionAvailable(AppSession.GetQuestionNumber()))
                {
                    //If questions have not finished
                    viewModel.Question = GetQuestionByOrder(AppSession.GetQuestionNumber());
                }
                else
                {
                    //All questions are done, call FinishSurvey Action
                    FinishSurvey();
                    return RedirectToAction("Finish", "Finish");
                }
            }
            else
            {   
                //Return question by option selected
                viewModel.Question = GetQuestionById(AppSession.GetFollowUpQuestions().First());

                //Remove question from FollowUp list
                AppSession.RemoveFollowUpQuestion(viewModel.Question.QID);
            }
            
            
            return View(viewModel);
        }

        
        //Post method to take respondent to next question and store current question in Session
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Survey(SurveyViewModel model)
        {   

            //Set question ID in answer from view model
            var answer = new Answer
            {
                Question_QID = model.Answer.Question_QID                
            };

            
            if (model.Type == "checkbox")
            {
                //Loop through checkbox answers
                foreach (var option in model.CheckBoxAnswers)
                {
                    //Option selected
                    if (option.IsSelected)
                    {
                        //Store option in Session
                        answer.Option_OID = option.Id;
                        AppSession.AddAnswer(answer);
                        if (option.NextQuestion != null)
                        {
                            if (AppSession.GetFollowUpQuestions() == null || AppSession.GetFollowUpQuestions().All(id => id != option.NextQuestion))
                            {
                                //Add followUp question 
                                AppSession.AddFollowUpQuestion(option.NextQuestion.Value);
                            }
                            
                        }
                    }
                }

                if (AppSession.GetFollowUpQuestions() == null || AppSession.GetFollowUpQuestions().Count() == 0)
                {
                    //No option selected,  increment questin order
                    AppSession.IncrementQuestionNumber();
                    return RedirectToAction("Survey");
                }
            }
            else
            {
                //Verify if user skipped question
                if (model.Answer.Option_OID == null && model.Answer.Text == null)
                {
                    //Skipped
                    AppSession.IncrementQuestionNumber();
                }
                else
                {
                    //Answered
                    answer.Option_OID = model.Answer.Option_OID;
                    answer.Text = model.Answer.Text;
                    //Store in Session
                    AppSession.IncrementQuestionNumber();
                    AppSession.AddAnswer(answer);
                }
            }


            return RedirectToAction("Survey");
        }



        //Get question by ID from DB
        public Question GetQuestionById(int id)
        {
            try
            {
                var question = _context.Questions.Single(q => q.QID == id);
                question.Options = _context.Options.Where(o => o.Question_QID == question.QID).ToList();
                question.Type = _context.Types.Single(t => t.TID == question.Type_TID);

                return question;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        //Get quesiton by Order from DB
        public Question GetQuestionByOrder(int order)
        {
            try
            {   
                var question = _context.Questions.Single(q => q.QuestionOrder == order);
                question.Options = _context.Options.Where(o => o.Question_QID == question.QID).ToList();
                question.Type = _context.Types.Single(t => t.TID == question.Type_TID);

                return question;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
           
        }

        //Check if question is available in DB
        public bool IsQuestionAvailable(int order)
        {
            return _context.Questions.Any(q => q.QuestionOrder == order);
        }

        //Finish Survey method ( respondent and answers from Session and store in DB )
        public void FinishSurvey()
        {
            //get respondent from Session
            Respondent respondent = AppSession.GetRespondent();
            try
            {
                //Store respondent in DB
                _context.Respondents.Add(respondent);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            
            

            //Questions answered
            if (AppSession.GetAnswers() != null)
            {
                //Get answers from Session
                try
                {
                    List<Answer> answers = AppSession.GetAnswers();

                    foreach (var answer in answers)
                    {
                        answer.Respondent_RID = respondent.RID;
                    }

                    //Store answers in DB
                    _context.Answers.AddRange(answers);
                    _context.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Clear Session
            AppSession.ClearSession();
            
        }

    }
}