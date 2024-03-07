using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using MSSaoPauloASP.NET.Models;
using MSSaoPauloASP.NET.EF;
using System.Net;

namespace MSSaoPauloASP.NET.Controllers
{
    public class PageController : Controller
    {
        // GET: SponsorRunnerPage
        public ActionResult SponsorARunnerPage()
        {
            DBModel dbmodel = new DBModel();
            //var getrunnername = dbmodel.Users.ToList();
            var getrunnername = dbmodel.Runners
                                .Include(i => i.User)
                                //.Include(i => i.Registrations)

                                .Select(i => i).ToList();

            SelectList list = new SelectList(getrunnername, "ToString");
            ViewBag.runnerlistname = list;

            return View();
        }

        // GET: RunnerMenu
        public ActionResult RunnerMenuPage()
        {
            return View();
        }

        // GET: Runner Menu Registration w/ buttons
        public ActionResult RegisterAsRunnerMenu()
        {
            return View();
        }

        // GET: Runner Registration 
        public ActionResult RegisterAsRunner()
        {
            //For Gender
            DBModel dbmodel = new DBModel();
            //var getrunnername = dbmodel.Users.ToList();
            var getgenderlist = dbmodel.Genders
                                .Select(i => i).ToList();
            SelectList list = new SelectList(getgenderlist, "ToString");
            ViewBag.genderList = list;

            //For Countries
            var getcountrylist = dbmodel.Countries
                                .Select(i => i).ToList();
            SelectList list2 = new SelectList(getcountrylist, "ToString");
            ViewBag.countryList = list2;

            return View();
        }

        //For RUNNER REGISTRATION adding
        //[HttpPost]
        //public ActionResult RegisterAsRunner(User _user)
        //{
        //    DBModel db = new DBModel();
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(_user);
        //        db.SaveChanges();

        //        return RedirectToAction("RunnerMenuPage");
        //    }
        //    else
        //    {
        //        return View(_user);
        //    }
        //}

        // GET: EditProfilePage
        public ActionResult EditProfilePage(string email)
        {
            DBModel db = new DBModel();

            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var runner = db.Runners.Where(i => i.Email == email).FirstOrDefault();

            ViewBag.GenderList = new SelectList(db.Genders, "Gender1", "Gender1", runner.Gender);
            ViewBag.CountryList = new SelectList(db.Countries, "CountryCode", "CountryName", runner.CountryCode);

            EditProfileViewModel model = new EditProfileViewModel()
            {
                FirstName = runner.User.FirstName,
                LastName = runner.User.LastName,
                Email = runner.Email,
                Gender = runner.Gender,
                DateOfBirth = runner.DateOfBirth,
                CountryCode = runner.CountryCode,
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        //Together --Start--
        [HttpPut]
        public ActionResult EditProfilePage(EditProfileViewModel runnerEditProfile)
        {
            DBModel db = new DBModel();

            if (ModelState.IsValid)
            {
                if (runnerEditProfile.Password != runnerEditProfile.PasswordAgain)
                {
                    ModelState.AddModelError("password", "Error! Password do not match!");
                }
            }
            else
            {
                db.SaveChanges();
            }

            ViewBag.GenderList = new SelectList(db.Genders, "Gender1", "Gender1");
            ViewBag.CountryList = new SelectList(db.Countries, "CountryCode", "CountryName");

            return View(runnerEditProfile);
        }
        // -- END --


        // GET: AdminMenu
        public ActionResult AdminMenuPage()
        {
            return View();
        }

        // GET: CoordinatorMenu
        public ActionResult CoordinatorMenuPage()
        {
            return View();
        }

        //ALL THE FINDMOREINFO PAGE - BUTTON
        // GET: ListOfCharities - Find out More info
        public ActionResult ListCharities()
        {
            DBModel db = new DBModel();
            var item = db.Charities
                .Select(i => i).ToList();

            return View(item);
        }
        //GET: Screen 11
        public ActionResult AboutMS2015Page()
        {
            return View();
        }
        //GET: Screen 12 With Interactive Map
        public ActionResult IMapPage()
        {
            return View();
        }
        //-----------------------------END----------------------------

        //-- FOR REGISTER EVENT WITH CONFIRMATION----------
        //GET: For RegisterEventPage
        public ActionResult RegisterEventPage()
        {
            DBModel db = new DBModel();
            var item = db.Charities
                .Select(i => i).ToList();

            return View(item);
        }
        public ActionResult RegisterEventConfirmPage()
        {
            return View();
        }
        //-----------------------------END----------------------------


    }
}