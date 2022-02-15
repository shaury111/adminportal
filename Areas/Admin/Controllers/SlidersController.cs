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
    public class SlidersController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/Sliders
        public async Task<ActionResult> Index()
        {
            return View(await db.HomeSliders.ToListAsync());
        }

        // GET: Admin/Sliders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeSlider homeSlider = await db.HomeSliders.FindAsync(id);
            if (homeSlider == null)
            {
                return HttpNotFound();
            }
            return View(homeSlider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,homePhoto,homestatement,fldstatus,flddoe,slidesc")] HomeSlider homeSlider)
        {
                string FileName = "";

                homeSlider.flddoe = System.DateTime.Now;

                HttpPostedFileBase file = Request.Files[0];

                if (file.FileName != "")
                {
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
                    //Its Create complete path to store in server.  
                    string SaveLocation = Server.MapPath("~/Uploadcpic") + "/" + FileName;
                    file.SaveAs(SaveLocation);
                    //To copy and save file into server.  
                    //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);

                }

            homeSlider.homePhoto = FileName;

            if (ModelState.IsValid)
            {
                db.HomeSliders.Add(homeSlider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(homeSlider);
        }

        // GET: Admin/Sliders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeSlider homeSlider = await db.HomeSliders.FindAsync(id);
            if (homeSlider == null)
            {
                return HttpNotFound();
            }
            return View(homeSlider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,homePhoto,homestatement,fldstatus,flddoe,slidesc")] HomeSlider homeSlider)
        {

            string FileName = "";

            try
            {
                HttpPostedFileBase file = Request.Files[0];

                if (file.FileName != "")
                {
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
                    //Its Create complete path to store in server.  
                    string SaveLocation = Server.MapPath("~/Uploadcpic") + "/" + FileName;
                    file.SaveAs(SaveLocation);
                    //To copy and save file into server.  
                    //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);
                    homeSlider.homePhoto = FileName;
                }
            }
            catch (Exception)
            {


            }


            if (ModelState.IsValid)
            {
                db.Entry(homeSlider).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(homeSlider);
        }

        // GET: Admin/Sliders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeSlider homeSlider = await db.HomeSliders.FindAsync(id);
            if (homeSlider == null)
            {
                return HttpNotFound();
            }
            return View(homeSlider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HomeSlider homeSlider = await db.HomeSliders.FindAsync(id);
            db.HomeSliders.Remove(homeSlider);
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
