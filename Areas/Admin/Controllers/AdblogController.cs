using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Ecommerce.Filters;
using SiteAllAdmin.Models;

namespace new_loginsystem.Areas.Admin.Controllers
{
    [AuthorizeUser(Roles = "Admin")]
    public class AdblogController : Controller
    {
        private readonly  JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/Adblog
        public async Task<ActionResult> Index()
        {
            var blogs = db.Blogs.Include(b => b.tblcategory);
            return View(await blogs.ToListAsync());
        }

        // GET: Admin/Adblog/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Adblog/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.tblcategories, "fldcatid", "fldcategoryname");
            return View();
        }

        // POST: Admin/Adblog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
      
        public async Task<ActionResult> Create([Bind(Include = "id,cid,blogtitle,blogDesc,blogimage,blogentrydate,fldextra,fldextra1,fldextra2,fldextra3,fldextra4")] Blog blog)
        {
            blog.blogentrydate = System.DateTime.Now;


            string FileName = "";
            HttpPostedFileBase file = Request.Files[0];
            if (file.FileName != "")
            {
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
                //Its Create complete path to store in server.  
                string SaveLocation = Server.MapPath("~/BlogImage") + "/" + FileName;
                file.SaveAs(SaveLocation);
                //To copy and save file into server.  
                //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);

            }
            blog.blogimage = FileName;

            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.tblcategories, "fldcatid", "fldcategoryname", blog.cid);
            return View(blog);
        }

        // GET: Admin/Adblog/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.tblcategories, "fldcatid", "fldcategoryname", blog.cid);
            return View(blog);
        }

        // POST: Admin/Adblog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,cid,blogtitle,blogDesc,blogimage,blogentrydate,fldextra,fldextra1,fldextra2,fldextra3,fldextra4")] Blog blog)
        {
            blog.fldextra = ""+System.DateTime.Now;

            //string FileName = "";
            //try
            //{
            //    HttpPostedFileBase file = Request.Files[0];

            //    if (file.FileName != "")
            //    {
            //        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
            //        //Its Create complete path to store in server.  
            //        string SaveLocation = Server.MapPath("~/BlogImage") + "/" + FileName;
            //        file.SaveAs(SaveLocation);
            //        blog.blogimage = FileName;
            //        //To copy and save file into server.  
            //        //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);

            //    }
            //}
            //catch (Exception)
            //{

               
            //}


            if (ModelState.IsValid)
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.tblcategories, "fldcatid", "fldcategoryname", blog.cid);
            return View(blog);
        }

        // GET: Admin/Adblog/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Adblog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
