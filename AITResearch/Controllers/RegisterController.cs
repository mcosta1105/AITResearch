using AITResearch.Models;
using AITResearch.ViewModels;
using System;
using System.Web.Mvc;

namespace AITResearch.Controllers
{
    public class RegisterController : Controller
    {
        
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var respondent = new Respondent
                {
                    Date = DateTime.Now.Date,
                    DoB = model.DoB.Date,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    IP_Address = GetIpAddress()

                };

                AppSession.SetRespondent(respondent);

                return RedirectToAction("Survey", "Survey");
            }


            return View();
        }

        public string GetIpAddress()
        {
            //Get IP through PROXY
            //====================================
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] address = ipAddress.Split(',');
                if (address.Length != 0)
                {
                    return address[0];
                }
            }
            //Across Web Http request
            ipAddress = context.Request.UserHostAddress;
            if (ipAddress.Trim() == "::1")
            {
                //It is local
                //This is for local(LAN) connected ID Address
                string stringHostName = System.Net.Dns.GetHostName();
                //Get IP Host Entry
                System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
                //Get IP Address From The Ip Host Entry Address List
                System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;
                try
                {
                    ipAddress = arrIpAddress[1].ToString();
                }
                catch
                {
                    try
                    {
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                            ipAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            ipAddress = "127.0.0.1";

                        }
                    }
                }

            }            
            return ipAddress;
        }
    }
}