using MSSaoPauloASP.NET.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSSaoPauloASP.NET.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginPage
        public ActionResult LoginPage()
        {
            return View();
        }

        //**Case Sensitive
        //db.Users.Where(x => String.Equals(x.UserName, userModel.UserName));
        //**Case In - sensitive
        //db.Users.Where(x => String.Equals(x.UserName, userModel.UserName, StringComparison.CurrentCultureIgnoreCase));

        [HttpPost] //To change from GET to POST action
        public ActionResult Authorize(User userModel)
        {
            using (DBModel db = new DBModel())
            {

                var userDetails = db.Users.Where(x => x.Email == userModel.Email &&
               x.Password == userModel.Password).FirstOrDefault();

                if (userDetails == null)
                {
                    //string LoginErrorMessage = "";
                    //userModel.LoginErrorMessage = "Incorrect Email or Password."

                    return RedirectToAction("LoginPage", "Login");
                    //return View("LoginPage", "Login");
                }

                else if (userDetails.RoleId == "R")
                {
                    Session["Email"] = userDetails.Email;
                    return RedirectToAction("RunnerMenuPage", "Page");
                }
                else if (userDetails.RoleId == "A")
                {
                    Session["Email"] = userDetails.Email;
                    return RedirectToAction("AdminMenuPage", "Page");
                }
                else /*if (userModel.RoleId == "C")*/
                {
                    Session["Email"] = userDetails.Email;
                    return RedirectToAction("CoordinatorMenuPage", "Page");
                }
                
            }
        }


    }
}