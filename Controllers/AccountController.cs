

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ecommerce.Utility;
using SiteAllAdmin.Models;

namespace new_loginsystem.Controllers
{
    public class AccountController : Controller
    {

        private JobPortalEntities db = new JobPortalEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AdminLogin()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult AdminLogin(Admintable objAdmintable)
        //{

        //    FormsAuthentication.Initialize();


        //    Admintable lonjadmin = db.Admintables.Where(x => x.adminname == objAdmintable.adminname).FirstOrDefault();

        //    if(lonjadmin!=null)
        //    {

        //        if(lonjadmin.adminpassword== objAdmintable.adminpassword)
        //        {




        //                // Create a new ticket used for authentication
        //                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
        //                   1, // Ticket version
        //                   lonjadmin.id + "_" + lonjadmin.adminname + "_" + lonjadmin.adminpassword + "_" + lonjadmin.roleid, // Username associated with ticket
        //                   DateTime.Now, // Date/time issued
        //                   DateTime.Now.AddHours(30), // Date/time to expire
        //                   true, // "true" for a persistent user cookie
        //                   lonjadmin.roleid+"", // User-data, in this case the roles
        //                   FormsAuthentication.FormsCookiePath);// Path cookie valid for

        //                // Encrypt the cookie using the machine key for secure transport
        //                string hash = FormsAuthentication.Encrypt(ticket);
        //                HttpCookie cookie = new HttpCookie(
        //                   FormsAuthentication.FormsCookieName, // Name of auth cookie
        //                   hash); // Hashed ticket

        //                // Set the cookie's expiration time to the tickets expiration time
        //                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

        //                // Add the cookie to the list for outgoing response
        //             HttpContext.Response.Cookies.Add(cookie);


        //            return RedirectToAction("index", "Dashboard", new { area = "Admin" });


        //            //    FormsAuthentication.SignOut();
        //            //FormsAuthentication.SetAuthCookie(lonjadmin.id + "_" + lonjadmin.adminname + "_" + lonjadmin.adminpassword + "_" + lonjadmin.roleid, true);


        //        }
        //        else
        //        {

        //            ViewBag.message = "Password Not Matched";
        //        }


        //    }
        //    else
        //    {
        //        ViewBag.message = "User Does not Exist";
        //    }

        //    return View();
        //}


        [HttpPost]
        public ActionResult AdminLogin(Admintable objAdmintable)
        {




            Admintable lonjadmin = db.Admintables.Where(x => x.adminname == objAdmintable.adminname).FirstOrDefault();

            if (lonjadmin != null)
            {

                if (lonjadmin.adminpassword == objAdmintable.adminpassword)
                {

                    //Session["UId"] = lonjadmin.id;
                    //Session["UserId"] = lonjadmin.adminname;
                    //Session["DisplayName"] = lonjadmin.adminname;
                    ////Session["Email"] = user.EmailId;
                    //if (lonjadmin.roleid != null && lonjadmin.roleid != 0)
                    //    Session["Role"] = lonjadmin.tblrole.fldrole;
                    //else
                    //    Session["Role"] = "";
                    //Session["RoleId"] = lonjadmin.roleid;


                    Response.Cookies["UId"].Value = EncryptDecrypt.Encrypt(lonjadmin.id.ToString(), true);
                    Response.Cookies["UserId"].Value = EncryptDecrypt.Encrypt(lonjadmin.id.ToString(), true);
                    Response.Cookies["DisplayName"].Value = EncryptDecrypt.Encrypt(lonjadmin.adminname, true);
                    Response.Cookies["RoleId"].Value = EncryptDecrypt.Encrypt(lonjadmin.tblrole.fldrole.ToString(), true);
                    if (lonjadmin.tblrole.fldrole != null && lonjadmin.roleid != 0)
                        Response.Cookies["Role"].Value = EncryptDecrypt.Encrypt(lonjadmin.tblrole.fldrole, true);
                    else
                        Response.Cookies["Role"].Value = "";


                    // ViewBag.redirectUrl = (!string.IsNullOrEmpty(returnUrl) ? HttpUtility.HtmlDecode(returnUrl) : "/");





                    return RedirectToAction("index", "Dashboard", new { area = "Admin" });


                    //    FormsAuthentication.SignOut();
                    //FormsAuthentication.SetAuthCookie(lonjadmin.id + "_" + lonjadmin.adminname + "_" + lonjadmin.adminpassword + "_" + lonjadmin.roleid, true);


                }
                else
                {

                    ViewBag.message = "Password Not Matched";
                }


            }
            else
            {
                ViewBag.message = "User Does not Exist";
            }

            return View();
        }


        [HttpPost]
        public ActionResult Index(UserDetail uid)
        {












            UserDetail d = db.UserDetails.Where(x => x.fldpassword == uid.fldpassword.ToString() && x.fldemail == uid.fldemail).FirstOrDefault();
            ////UserDetail d = db.UserDetails.Find(uid);
            if (d != null)
            {

                if (d.fldstatus == true)
                { 


                 
                    Response.Cookies["UId"].Value = EncryptDecrypt.Encrypt(d.id.ToString(), true);
                    Response.Cookies["UserId"].Value = EncryptDecrypt.Encrypt(d.id.ToString(), true);
                    Response.Cookies["DisplayName"].Value = EncryptDecrypt.Encrypt(d.fldName, true);
                    Response.Cookies["RoleId"].Value = EncryptDecrypt.Encrypt(d.tblrole.fldrole.ToString(), true);
                    if (d.tblrole.fldrole != null && d.roletype != 0)
                        Response.Cookies["Role"].Value = EncryptDecrypt.Encrypt(d.tblrole.fldrole, true);
                    else
                        Response.Cookies["Role"].Value = "";

                    //FormsAuthentication.SignOut();
                    //FormsAuthentication.SetAuthCookie(d.id + "_" + d.fldName + "_" + d.fldpassword + "_" + d.roletype, true);
                    return RedirectToAction("checkstatus", "Home");
                }
                else
                {
                    ViewBag.msg = "This Account Is deactivated right now";
                    return View();
                }


            }

            else
            {
                ViewBag.msg = "Profile Detail not Found";
                return View();
            }






           
        }




        #region Logout ...
        public ActionResult LogOut()
        {
            Session["UId"] = null;
            Session.Clear();
            if (Request.Cookies["Role"] != null && Request.Cookies["UId"] != null)
            Response.Cookies["Role"].Expires = GetIndianTime.getDateTime().AddDays(-1);
            Response.Cookies["UId"].Expires = GetIndianTime.getDateTime().AddDays(-1);

            return RedirectToAction("Index", "Account");
        }
        #endregion






        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("index", "Account");
        //}
    }
}