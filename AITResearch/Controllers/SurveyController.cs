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

            if (AppSession.GetFollowUpQuestions() == null)
            {
                //viewModel.Question = GetQuestionByOrder(7);
                viewModel.Question = GetQuestionByOrder(AppSession.GetQuestionNumber());
            }
            else
            {
                viewModel.Question = GetQuestionById(AppSession.GetFollowUpQuestions().First());
            }
            
            
            return View(viewModel);
        }

        
        [HttpPost]
        public ActionResult Survey(SurveyViewModel model)
        {
            if (model.Answer.Option.NextQuestion == null)
            {
                AppSession.IncrementQuestionNumber();
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

    }
}