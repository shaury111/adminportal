using Ecommerce.Filters;
using Ecommerce.Utility;
using new_loginsystem.Models;
using SiteAllAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace new_loginsystem.Controllers
{

    [AuthorizeUser(Roles = "users")]
    public class UserNavigationController : Controller
    {

        private  readonly JobPortalEntities  db = new JobPortalEntities();
        // GET: UserNavigation
        public ActionResult AccountStatus()
        {
            int id = Convert.ToInt32(EncryptDecrypt.Decrypt(HttpContext.Request.Cookies["UId"].Value.ToString()));
            UserDetail d = db.UserDetails.Find(id);
           
            ViewBag.statushistiry = db.StatusKeyPairs.Where(x => x.cid == d.id);


            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Notification()
        {

            int id = Convert.ToInt32(EncryptDecrypt.Decrypt(HttpContext.Request.Cookies["UId"].Value.ToString()));
            UserDetail d = db.UserDetails.Find(id);
            ViewBag.Noticelist = db.tblnotifications.Where(x => x.cid == d.id).ToList();
            return View();
        }

        public ActionResult Payments()
        {

            int id = Convert.ToInt32(EncryptDecrypt.Decrypt(HttpContext.Request.Cookies["UId"].Value.ToString()));
            UserDetail d = db.UserDetails.Find(id);
            ViewBag.PaymentList = db.tblPayments.Where(x => x.cid == d.id).ToList();
            return View();
        }

        public ActionResult HelpDesk()
        {
            int id = Convert.ToInt32(EncryptDecrypt.Decrypt(HttpContext.Request.Cookies["UId"].Value.ToString()));
            UserDetail d = db.UserDetails.Find(id);
            tbl_customercomplaint c = new tbl_customercomplaint();
            c.cid = d.id;
            return View(c);
            


        }

        [HttpPost]
        public ActionResult HelpDesk(tbl_customercomplaint tbl_customercomplaint)
        {
            tbl_customercomplaint.comp_date = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tbl_customercomplaint.Add(tbl_customercomplaint);
                ViewBag.msgstatus = "Complaint Registered Successfully";
                db.SaveChanges();
            }

            int id = Convert.ToInt32(EncryptDecrypt.Decrypt(HttpContext.Request.Cookies["UId"].Value.ToString()));
            UserDetail d = db.UserDetails.Find(id);
            return View(tbl_customercomplaint=new tbl_customercomplaint() { cid=d.id});
        }


        public ActionResult Product()
        {

            ViewBag.userprod= db.tblproducts.OrderByDescending(x => x.id).Take(4);
            return View();
        }
    }
}