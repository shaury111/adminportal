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
    public class BlogCategoryController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/tblcategories
        public async Task<ActionResult> Index()
        {
            return View(await db.tblcategories.ToListAsync());
        }

        // GET: Admin/tblcategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = await db.tblcategories.FindAsync(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // GET: Admin/tblcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "fldcatid,fldcategoryname,fldcategorytitle,fldcategorykeyword,flddescription,IsShow,fldextra,fldextra1,fldextra2,fldextra3,fldstatus")] tblcategory tblcategory)
        {
            if (ModelState.IsValid)
            {
                db.tblcategories.Add(tblcategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblcategory);
        }

        // GET: Admin/tblcategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = await db.tblcategories.FindAsync(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // POST: Admin/tblcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "fldcatid,fldcategoryname,fldcategorytitle,fldcategorykeyword,flddescription,IsShow,fldextra,fldextra1,fldextra2,fldextra3,fldstatus")] tblcategory tblcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcategory).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblcategory);
        }

        // GET: Admin/tblcategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = await db.tblcategories.FindAsync(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // POST: Admin/tblcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblcategory tblcategory = await db.tblcategories.FindAsync(id);
            db.tblcategories.Remove(tblcategory);
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
