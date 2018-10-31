using AITResearch.Models;
using AITResearch.ViewModels;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AITResearch.Controllers
{
    public class LoginController : Controller
    {
        //Declare DB Context
        private AitrDbContext _context;

        public LoginController()
        {
            _context = new AitrDbContext();
        }
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }

        //Post: Login
        [HttpPost]
        public ActionResult Login(LoginFormViewModel model)
        {

            Staff staff = new Staff()
            {
                Username = model.Username,
                Password = model.Password
            };

            staff = GetStaff(staff);

            if (staff != null)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);

                var authTicket = new FormsAuthenticationTicket(1, staff.Username, DateTime.Now, DateTime.Now.AddMinutes(30), false, staff.Username);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password, try again.");
                return View(model);
            }
        }

        public Staff GetStaff(Staff staff)
        {
            return _context.Staffs.Where(s => s.Username.ToLower() == staff.Username.ToLower() && s.Password == staff.Password).FirstOrDefault();
        }


    }


    
}