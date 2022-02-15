using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteAllAdmin.Models;

namespace new_loginsystem.Areas.Admin.Controllers
{
    public class AddextrafeaturesController : Controller
    {
        private readonly JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/Addextrafeatures
        public async Task<ActionResult> Index()
        {
            var addextrafeatures = db.Addextrafeatures.Include(a => a.UserDetail);
            return View(await addextrafeatures.ToListAsync());
        }

        // GET: Admin/Addextrafeatures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addextrafeature addextrafeature = await db.Addextrafeatures.FindAsync(id);
            if (addextrafeature == null)
            {
                return HttpNotFound();
            }
            return View(addextrafeature);
        }

        // GET: Admin/Addextrafeatures/Create
        public ActionResult Create()
        {
            ViewBag.rfid = new SelectList(db.UserDetails, "id", "fldName");
            return View();
        }

        // POST: Admin/Addextrafeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,rfid,columnname,columnvalue")] Addextrafeature addextrafeature)
        {
            if (ModelState.IsValid)
            {
                db.Addextrafeatures.Add(addextrafeature);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.rfid = new SelectList(db.UserDetails, "id", "fldName", addextrafeature.rfid);
            return View(addextrafeature);
        }

        // GET: Admin/Addextrafeatures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addextrafeature addextrafeature = await db.Addextrafeatures.FindAsync(id);
            if (addextrafeature == null)
            {
                return HttpNotFound();
            }
            ViewBag.rfid = new SelectList(db.UserDetails, "id", "fldName", addextrafeature.rfid);
            return View(addextrafeature);
        }

        // POST: Admin/Addextrafeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,rfid,columnname,columnvalue")] Addextrafeature addextrafeature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addextrafeature).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rfid = new SelectList(db.UserDetails, "id", "fldName", addextrafeature.rfid);
            return View(addextrafeature);
        }

        // GET: Admin/Addextrafeatures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addextrafeature addextrafeature = await db.Addextrafeatures.FindAsync(id);
            if (addextrafeature == null)
            {
                return HttpNotFound();
            }
            return View(addextrafeature);
        }

        // POST: Admin/Addextrafeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Addextrafeature addextrafeature = await db.Addextrafeatures.FindAsync(id);
            db.Addextrafeatures.Remove(addextrafeature);
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
