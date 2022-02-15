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
    public class adProductController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/adProduct
        public async Task<ActionResult> Index()
        {
            return View(await db.tblproducts.ToListAsync());
        }

        // GET: Admin/adProduct/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblproduct tblproduct = await db.tblproducts.FindAsync(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        // GET: Admin/adProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/adProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,fldprodtitle,fldprodsubtitle,flddescription,entrydate,fldseotitle,fldseokeyword,fldextra,fldextra1,productimage")] tblproduct tblproduct)
        {


            tblproduct.entrydate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tblproducts.Add(tblproduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblproduct);
        }

        // GET: Admin/adProduct/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblproduct tblproduct = await db.tblproducts.FindAsync(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        // POST: Admin/adProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,fldprodtitle,fldprodsubtitle,flddescription,entrydate,fldseotitle,fldseokeyword,fldextra,fldextra1,productimage")] tblproduct tblproduct)
        {
            tblproduct.fldextra1 =""+ System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(tblproduct).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblproduct);
        }

        // GET: Admin/adProduct/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblproduct tblproduct = await db.tblproducts.FindAsync(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        // POST: Admin/adProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblproduct tblproduct = await db.tblproducts.FindAsync(id);
            db.tblproducts.Remove(tblproduct);
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
