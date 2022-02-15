using Ecommerce.Filters;
using Ecommerce.Utility;
using SiteAllAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace new_loginsystem.Controllers
{
    public class HomeController : Controller
    {

        private JobPortalEntities db = new JobPortalEntities();

        //[Authorize(Roles = "users")]
        [AuthorizeUser(Roles = "users")]
        public ActionResult checkstatus()
        {

            int id = Convert.ToInt32(EncryptDecrypt.Decrypt(HttpContext.Request.Cookies["UId"].Value.ToString()));
            UserDetail d = db.UserDetails.Find(id);
            ViewBag.Noticelist = db.tblnotifications.Where(x => x.cid == d.id).ToList();
            ViewBag.totalnotice = db.tblnotifications.Where(x => x.cid == d.id).Count();
            ViewBag.statushistiry = db.StatusKeyPairs.Where(x => x.cid == d.id).Take(2);


            return View(d);

        }



       




        public ActionResult index()
        {

            HomeSlider m = db.HomeSliders.OrderBy(x => x.id).FirstOrDefault();
            ViewBag.banner = m;
            ViewBag.blogs = db.Blogs.OrderByDescending(x => x.id).Take(4);


            ViewBag.homeprod = db.tblproducts.OrderByDescending(x => x.id).Take(4);
            //ViewBag.blogs = db.Blogs.OrderByDescending(x => x.id).Take(4);

           Seosetings("Home");

            return View();
        }

        private void Seosetings(string pagename)
        {
            SeoSetting s = db.SeoSettings.Where(x => x.PageName == pagename).FirstOrDefault();
            ViewBag.Title = s.Pagetitle;
            ViewBag.pagedesciption = s.pagedesciption;
            ViewBag.keywords = s.keywords;
        }

        public ActionResult Bloghome()
        {
            //Seosetings("Blog");
            return View(db.Blogs.OrderByDescending(x=>x.id).Take(4));

           
        }

        public ActionResult About()
        {
            Seosetings("About");
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult ApplyNow()
        {

            return View();
        }

        public JsonResult Sitedetails()
        {




            return Json(db.SiteSettings.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Services()
        {
            Seosetings("Services");


            return View();
        }

        public ActionResult vissionmission()
        {
            Seosetings("Vission");

            return View();
        }

        public ActionResult History()
        {
            Seosetings("History");
            return View();
        }
        public ActionResult Policies()
        {
            Seosetings("Policies");

            return View();
        }

        public ActionResult Privacy()
        {
            Seosetings("Policies");

            return View();
        }
        public ActionResult termConditions()
        {
            //Seosetings("Policies");

            return View();
        }

        public ActionResult InspiredBy()
        {

            return View();
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}