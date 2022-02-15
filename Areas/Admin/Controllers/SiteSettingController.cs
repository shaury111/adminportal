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
    public class SiteSettingController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/SiteSetting
        public async Task<ActionResult> Index()
        {
            return View(await db.SiteSettings.ToListAsync());
        }

        // GET: Admin/SiteSetting/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSetting siteSetting = await db.SiteSettings.FindAsync(id);
            if (siteSetting == null)
            {
                return HttpNotFound();
            }
            return View(siteSetting);
        }

        // GET: Admin/SiteSetting/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/SiteSetting/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "id,sitephoneno,siteemailid,sitecontactno2,siteAddress,sitelogo,fblink,twiterlink,gpluslink,shortaddress,sitename,shortdescription")] SiteSetting siteSetting)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SiteSettings.Add(siteSetting);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(siteSetting);
        //}

        // GET: Admin/SiteSetting/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSetting siteSetting = await db.SiteSettings.FindAsync(id);
            if (siteSetting == null)
            {
                return HttpNotFound();
            }
            return View(siteSetting);
        }

        // POST: Admin/SiteSetting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteSetting).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(siteSetting);
        }

        // GET: Admin/SiteSetting/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSetting siteSetting = await db.SiteSettings.FindAsync(id);
            if (siteSetting == null)
            {
                return HttpNotFound();
            }
            return View(siteSetting);
        }

        // POST: Admin/SiteSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SiteSetting siteSetting = await db.SiteSettings.FindAsync(id);
            db.SiteSettings.Remove(siteSetting);
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
