using Ecommerce.Filters;
using SiteAllAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace new_loginsystem.Areas.Admin.Controllers
{

    [AuthorizeUser(Roles = "Admin")]
    public class ImgcController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();
        // GET: Admin/Imgc
        public JsonResult fetchblogimg(int? id)
        {

            int blogid = Convert.ToInt32(id);

            Blog objblog = db.Blogs.Where(x => x.id == blogid).FirstOrDefault();
            if (objblog!=null)
            {
                objblog.blogimage = "/BlogImage/" + objblog.blogimage+ "?w=160&h=100";
            }
            else
            {
                objblog.blogimage = "/img/figure/2.jpg?w=160&h=100";
            }


            var result = new {
                src= objblog.blogimage,
                id= objblog.id
            };


            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadBlog()
        {
            // Checking no of files injected in Request object  




            if (Request.Files.Count > 0)
            {

                string p = Request.Form["jobid"];
                int imageid = Convert.ToInt32(Request.Form["imageid"]);



                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname, imagename;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = imagename = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = imagename = file.FileName;
                        }

                        Blog objjobimage = db.Blogs.Where(x => x.id == imageid).FirstOrDefault();

                        if (objjobimage != null)
                        {

                            fname = Path.Combine(Server.MapPath("~/BlogImage/"), fname);
                            file.SaveAs(fname);
                            objjobimage.blogimage = imagename;
                            db.Entry(objjobimage).State = EntityState.Modified;
                            db.SaveChanges();

                        }

                        else
                        {
                            //fname = Path.Combine(Server.MapPath("~/BlogImage/"), fname);
                            //file.SaveAs(fname);
                            //Blog objomage = new Blog();
                            //objomage.fldjobimgid = 0;
                            //objomage.fldfilename = imagename;
                            //objomage.joblistid = Convert.ToInt32(p);
                            //objomage.fldstatus = true;
                            //objomage.fldextra = objomage.fldextra1 = objomage.fldextra2 = objomage.fldextra3 = "";
                            //db.tbljobimages.Add(objomage);
                            //db.SaveChanges();
                        }
                        // Get the complete folder path and store the file inside it.  


                    }

                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.InnerException);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        [HttpPost]
        public ActionResult Uploadpro()
        {
            // Checking no of files injected in Request object  




            if (Request.Files.Count > 0)
            {

                string p = Request.Form["jobid"];
                int imageid = Convert.ToInt32(Request.Form["imageid"]);



                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname, imagename;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = imagename = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = imagename = file.FileName;
                        }

                       tblproduct  objjobimage = db.tblproducts.Where(x => x.id == imageid).FirstOrDefault();

                        if (objjobimage != null)
                        {

                            fname = Path.Combine(Server.MapPath("~/BlogImage/"), fname);
                            file.SaveAs(fname);
                            objjobimage.productimage = imagename;
                            db.Entry(objjobimage).State = EntityState.Modified;
                            db.SaveChanges();

                        }

                        else
                        {
                            //fname = Path.Combine(Server.MapPath("~/BlogImage/"), fname);
                            //file.SaveAs(fname);
                            //Blog objomage = new Blog();
                            //objomage.fldjobimgid = 0;
                            //objomage.fldfilename = imagename;
                            //objomage.joblistid = Convert.ToInt32(p);
                            //objomage.fldstatus = true;
                            //objomage.fldextra = objomage.fldextra1 = objomage.fldextra2 = objomage.fldextra3 = "";
                            //db.tbljobimages.Add(objomage);
                            //db.SaveChanges();
                        }
                        // Get the complete folder path and store the file inside it.  


                    }

                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.InnerException);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }




        public JsonResult fetchprogimg(int? id)
        {

            int blogid = Convert.ToInt32(id);

            tblproduct objblog = db.tblproducts.Where(x => x.id == blogid).FirstOrDefault();
            if (objblog != null)
            {
                objblog.productimage = "/BlogImage/" + objblog.productimage + "?w=160&h=100";
            }
            else
            {
                objblog.productimage = "/img/figure/2.jpg?w=160&h=100";
            }


            var result = new
            {
                src = objblog.productimage,
                id = objblog.id
            };


            return Json(result, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}