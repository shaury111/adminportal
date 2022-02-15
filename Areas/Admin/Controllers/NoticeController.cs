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
    public class NoticeController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/Notice
        public async Task<ActionResult> Index()
        {
            var tblnotifications = db.tblnotifications.Include(t => t.UserDetail);
            return View(await tblnotifications.ToListAsync());
        }

        // GET: Admin/Notice/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnotification tblnotification = await db.tblnotifications.FindAsync(id);
            if (tblnotification == null)
            {
                return HttpNotFound();
            }
            return View(tblnotification);
        }

        // GET: Admin/Notice/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName");
            return View();
        }

        // POST: Admin/Notice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,cid,NoticeTitle,NoticeDescription,NoticeDate,fldstatus,attachment,fldextra,fldextra1,fldextra2,fldextra3")] tblnotification tblnotification)
        {

            tblnotification.NoticeDate = System.DateTime.Now;
            tblnotification.fldstatus = true;

            if (ModelState.IsValid)
            {
                db.tblnotifications.Add(tblnotification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName", tblnotification.cid);
            return View(tblnotification);
        }

        // GET: Admin/Notice/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnotification tblnotification = await db.tblnotifications.FindAsync(id);
            if (tblnotification == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName", tblnotification.cid);
            return View(tblnotification);
        }

        // POST: Admin/Notice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,cid,NoticeTitle,NoticeDescription,NoticeDate,fldstatus,attachment,fldextra,fldextra1,fldextra2,fldextra3")] tblnotification tblnotification)
        {
            tblnotification.NoticeDate = System.DateTime.Now;
            tblnotification.fldstatus = true;
            if (ModelState.IsValid)
            {
                db.Entry(tblnotification).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName", tblnotification.cid);
            return View(tblnotification);
        }

        // GET: Admin/Notice/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnotification tblnotification = await db.tblnotifications.FindAsync(id);
            if (tblnotification == null)
            {
                return HttpNotFound();
            }
            return View(tblnotification);
        }

        // POST: Admin/Notice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblnotification tblnotification = await db.tblnotifications.FindAsync(id);
            db.tblnotifications.Remove(tblnotification);
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
