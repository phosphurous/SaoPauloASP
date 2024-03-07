using MSSaoPauloASP.NET.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSSaoPauloASP.NET.Controllers
{
    public class RunnerRegistrationController : Controller
    {
        private DBModel db = new DBModel();

        // GET: RunnerRegistration
        public ActionResult RunnerRegistrationPage()
        {
            ViewBag.GenderList = new SelectList (db.Genders, "Gender1", "Gender1");
            ViewBag.CountryList = new SelectList(db.Countries, "CountryCode", "CountryName");

            return View();
        }

        [HttpPost]
        public ActionResult RunnerRegistrationPage(Models.RunnerRegistrationViewModel runnerData)
        {
            if (ModelState.IsValid)
            {
                //check if the two is equal. s.Email = EF. runnerData = to viewmodel.
                var email = db.Users.Where(s => s.Email == runnerData.Email).FirstOrDefault();

                if (email != null)
                {
                    ModelState.AddModelError("email", "Email exists!");

                    ViewBag.GenderList = new SelectList(db.Genders, "Gender1", "Gender1");
                    ViewBag.CountryList = new SelectList(db.Countries, "CountryCode", "CountryName");
                    return View(runnerData);
                }
                else
                {
                    db.Users.Add(new EF.User()
                    {
                        Email = runnerData.Email,
                        Password = runnerData.Password,
                        FirstName = runnerData.FirstName,
                        LastName = runnerData.LastName,
                        RoleId = "R"
                    });

                    db.Runners.Add(new EF.Runner()
                    {
                        Email = runnerData.Email,
                        Gender = runnerData.Gender,
                        DateOfBirth = runnerData.DateOfBirth,
                        CountryCode = runnerData.CountryCode
                    });
                }

                db.SaveChanges();

                return RedirectToAction("RunnerRegistrationPage");
            }

            ViewBag.GenderList = new SelectList(db.Genders, "Gender1", "Gender1");
            ViewBag.CountryList = new SelectList(db.Countries, "CountryCode", "CountryName");

            return View(runnerData);
        }


    }
}