
using new_loginsystem.Models;
using SiteAllAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace new_loginsystem.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        private JobPortalEntities db = new JobPortalEntities();
        public ActionResult Index()
        {


            //ViewBag.sidebanner=db.tblcategories.blo


            Seosetings("Blog");
            return View(db.Blogs);
        }

        private void Seosetings(string pagename)
        {
            SeoSetting s = db.SeoSettings.Where(x => x.PageName == pagename).FirstOrDefault();
            ViewBag.Title = s.Pagetitle;
            ViewBag.pagedesciption = s.pagedesciption;
            ViewBag.keywords = s.keywords;
        }

        // GET: Blog/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int bid = Convert.ToInt32(id.Split('_')[1]);
            Blog blog =  db.Blogs.Find(bid);
            ViewBag.Title = blog.blogtitle;
            ViewBag.pagedesciption = blog.blogDesc;
            ViewBag.keywords =blog.blogtitle;
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public ActionResult Enquiry(UserEnquiryModel UserEnquiryModel)
        {

            if(ModelState.IsValid)
            {

                if(!db.HomeEnquiries.Any(
                    s => s.ApplicantEmail == UserEnquiryModel.fldmobile
                    ||
                     s.ApplicantMobile==UserEnquiryModel.fldmobile
                                        ))
                {
                    HomeEnquiry objhomenquiry = new HomeEnquiry
                    {

                        ApplicantName = UserEnquiryModel.fldname,
                        ApplicantMobile = UserEnquiryModel.fldmobile,
                        ApplicantEmail = UserEnquiryModel.fldemail,
                        Applydate = System.DateTime.Now,
                        ApplicantAddress = UserEnquiryModel.fldsubject,
                        fldextra = UserEnquiryModel.fldextra,
                        fldextra1 = "" + UserEnquiryModel.refid
                    };

                    db.HomeEnquiries.Add(objhomenquiry);
                    db.SaveChanges();
                    ViewBag.msg = "Enquiry Submitted Successfully";
                }

                else
                {

                    ViewBag.msg = "Your Detail Already Taken";
                }


                
            }

          

            return View();
        }

        // GET: Blog/Create
       
        
    }
}
