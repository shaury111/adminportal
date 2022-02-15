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
    public class SeoSettingController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/SeoSetting
        public async Task<ActionResult> Index()
        {
            return View(await db.SeoSettings.ToListAsync());
        }

        // GET: Admin/SeoSetting/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeoSetting seoSetting = await db.SeoSettings.FindAsync(id);
            if (seoSetting == null)
            {
                return HttpNotFound();
            }
            return View(seoSetting);
        }

        // GET: Admin/SeoSetting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SeoSetting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Pagetitle,pagedesciption,pagemeta,keywords,PageName")] SeoSetting seoSetting)
        {
            if (ModelState.IsValid)
            {
                db.SeoSettings.Add(seoSetting);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(seoSetting);
        }

        // GET: Admin/SeoSetting/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeoSetting seoSetting = await db.SeoSettings.FindAsync(id);
            if (seoSetting == null)
            {
                return HttpNotFound();
            }
            return View(seoSetting);
        }

        // POST: Admin/SeoSetting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Pagetitle,pagedesciption,pagemeta,keywords,PageName")] SeoSetting seoSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seoSetting).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(seoSetting);
        }

        // GET: Admin/SeoSetting/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeoSetting seoSetting = await db.SeoSettings.FindAsync(id);
            if (seoSetting == null)
            {
                return HttpNotFound();
            }
            return View(seoSetting);
        }

        // POST: Admin/SeoSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SeoSetting seoSetting = await db.SeoSettings.FindAsync(id);
            db.SeoSettings.Remove(seoSetting);
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
