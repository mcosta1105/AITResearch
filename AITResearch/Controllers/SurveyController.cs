using AITResearch.Models;
using AITResearch.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace AITResearch.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey

        private AitrDbContext _context;
        

        //Constructor
        public SurveyController()
        {
            _context = new AitrDbContext();
        }

        [HttpGet]
        public ActionResult Survey()
        {
            
            var viewModel = new SurveyViewModel();

            //Verify if there is any followUp question in Session
            if (AppSession.GetFollowUpQuestions() == null || AppSession.GetFollowUpQuestions().Count() == 0)
            {
                //Return question by Order
                //viewModel.Question = GetQuestionByOrder(8);

                if(IsQuestionAvailable(AppSession.GetQuestionNumber()))
                {
                    viewModel.Question = GetQuestionByOrder(AppSession.GetQuestionNumber());
                }
                else
                {
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

        
        [HttpPost]
        public ActionResult Survey(SurveyViewModel model)
        {   
            var answer = new Answer
            {
                Question_QID = model.Answer.Question_QID                
            };


            if (model.Type == "checkbox")
            {
                foreach (var option in model.CheckBoxAnswers)
                {
                    if (option.IsSelected)
                    {
                        answer.Option_OID = option.Id;

                        if (option.NextQuestion != null)
                        {
                            AppSession.AddFollowUpQuestion(option.NextQuestion.Value);
                        }
                    }
                }
                if (AppSession.GetFollowUpQuestions() == null || AppSession.GetFollowUpQuestions().Count() == 0)
                {
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
                    AppSession.IncrementQuestionNumber();
                }
            }
            
            

            return RedirectToAction("Survey");
        }




        public Question GetQuestionById(int id)
        {
            var question = _context.Questions.Single(q => q.QID == id);
            question.Options = _context.Options.Where(o => o.Question_QID == question.QID).ToList();
            question.Type = _context.Types.Single(t => t.TID == question.Type_TID);
                        
            return question;
        }

        public Question GetQuestionByOrder(int order)
        {
            var question = _context.Questions.Single(q => q.QuestionOrder == order);
            question.Options = _context.Options.Where(o => o.Question_QID == question.QID).ToList();
            question.Type = _context.Types.Single(t => t.TID == question.Type_TID);
            return question;
           
        }

        //Check if question is available in DB
        public bool IsQuestionAvailable(int order)
        {
            return _context.Questions.Any(q => q.QuestionOrder == order);
        }

        public void FinishSurvey()
        {

        }

    }
}