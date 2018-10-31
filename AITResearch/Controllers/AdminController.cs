using AITResearch.CustomAttributes;
using AITResearch.Models;
using AITResearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AITResearch.Controllers
{
    [CustomAuthorize]
    public class AdminController : Controller
    {
        //Declare DB Context
        private AitrDbContext _context;

        //Constructor
        public AdminController()
        {
            _context = new AitrDbContext();
        }

        // GET: Admin
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Admin()
        {
            List<Respondent> respondents = new List<Respondent>();

            //Check if Search List in Session is null
            if (AppSession.GetSearchList() == null)
            {
                //Get all respondents from database
                respondents = GetRespondents();
            }
            else
            {
                //Filter respondents
                List<int> searchList = AppSession.GetSearchList();
                foreach (var id in searchList)
                {
                    respondents.Add(GetRespondentsById(id));
                }
            }

            //Order respondents by last name
            respondents = respondents.OrderBy(o => o.LastName == "Anonymous").ThenBy(o => o.LastName).ToList();
           
            //Get all options from db
            List<Option> options = GetOptions();


            List<RespondentRowModel> row = new List<RespondentRowModel>();
            
            //Set respondents to table row
            foreach (var respondent in respondents)
            {
                var respondentRow = new RespondentRowModel
                {
                    FirstName = respondent.FirstName,
                    LastName = respondent.LastName,
                    Phone = respondent.Phone
                    
                };
                //Check if email is null
                if (respondent.RespondentAnswers.Find(a => a.Question_QID == 1) != null)
                {
                    respondentRow.Email = respondent.RespondentAnswers.Find(a => a.Question_QID == 1).Text;
                }

                //Check if gender is null
                if (respondent.RespondentAnswers.Find(a => a.Question_QID == 2) != null)
                {
                    var gender = respondent.RespondentAnswers.Find(a => a.Question_QID == 2).Option_OID;
                    respondentRow.Gender = options.Find(o => o.OID == gender).Value;
                }

                //Check if Age range is null
                if (respondent.RespondentAnswers.Find(a => a.Question_QID == 3) != null)
                {
                    var ageRange = respondent.RespondentAnswers.Find(a => a.Question_QID == 3).Option_OID;
                    respondentRow.AgeRange = options.Find(o => o.OID == ageRange).Value;
                }


                row.Add(respondentRow);
                
            }

            //Set respondents rows to view model
            var viewModel = new AdminViewModel
            {
                Respondents = row
            };
            return View(viewModel);
        }

        //Post search form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Set search results to list
                List<Answer> answers = Search(model.SearchInput);


                List<int> respondentsId = new List<int>();
                foreach (var answer in answers)
                {
                    //Check if respondent is already found
                    if (respondentsId.All(r => r != answer.Respondent_RID))
                    {
                        //Then add answers
                        respondentsId.Add(answer.Respondent_RID);
                    }

                }

                //Store filtered respondents in session
                AppSession.SetSearchList(respondentsId);

                //Update view
                return RedirectToAction(nameof(Admin));
            }
            return RedirectToAction(nameof(Admin));
        }


        //Get all respondents from database
        public List<Respondent> GetRespondents()
        {
            try
            {
                return _context.Respondents
                .Include(a => a.RespondentAnswers).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        //Get all options
        public List<Option> GetOptions()
        {
            try
            {
                return _context.Options.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //Search
        public List<Answer> Search(string text)
        {
            try
            {
                return _context.Answers
                    .Include(r => r.Respondent)
                    .Include(o => o.Option)
                    .Where(a => a.Text.Contains(text)
                                || a.Option.Value.Contains(text)
                                || a.Respondent.LastName.Contains(text)
                                || a.Respondent.FirstName.Contains(text)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        //Get respondent by id
        public Respondent GetRespondentsById(int id)
        {
            try
            {
                return _context.Respondents
                .Include(an => an.RespondentAnswers)
                .FirstOrDefault(u => u.RID == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public ActionResult Logout()
        {
            //Clear Session
            AppSession.ClearSession();
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }

}