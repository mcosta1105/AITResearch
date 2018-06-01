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
        


        public SurveyController()
        {
            _context = new AitrDbContext();
        }

        [HttpGet]
        public ActionResult Survey()
        {

            var viewModel = new SurveyViewModel
            {
                Question = GetQuestionByOrder(AppSession.GetQuestionNumber())
            };
            return View(viewModel);
        }

        
        [HttpPost]
        public ActionResult Survey(SurveyViewModel model)
        {
            AppSession.IncrementQuestionNumber();

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