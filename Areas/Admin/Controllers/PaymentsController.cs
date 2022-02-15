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
    public class PaymentsController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/Payments
        public async Task<ActionResult> Index()
        {
            var tblPayments = db.tblPayments.Include(t => t.UserDetail);
            return View(await tblPayments.ToListAsync());
        }

        // GET: Admin/Payments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment tblPayment = await db.tblPayments.FindAsync(id);
            if (tblPayment == null)
            {
                return HttpNotFound();
            }
            return View(tblPayment);
        }

        // GET: Admin/Payments/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName");
            return View();
        }

        // POST: Admin/Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,cid,InvTitle,InvDesc,PublishedDate,InvDocument,invStatus,fldextra,fldextra1,fldextra2")] tblPayment tblPayment)
        {

            tblPayment.PublishedDate = System.DateTime.Now;
            tblPayment.invStatus = true;


            string FileName = "";

            HttpPostedFileBase file = Request.Files[0];

            if (file != null)
            {
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
                //Its Create complete path to store in server.  
                string SaveLocation = Server.MapPath("~/Uploadcpic") + "/" + FileName;
                file.SaveAs(SaveLocation);
                //To copy and save file into server.  
                //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);

            }

            //Add Current Date To Attached File Name  



            tblPayment.InvDocument = FileName;

            if (ModelState.IsValid)
            {
                db.tblPayments.Add(tblPayment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName", tblPayment.cid);
            return View(tblPayment);
        }

        // GET: Admin/Payments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment tblPayment = await db.tblPayments.FindAsync(id);
            if (tblPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName", tblPayment.cid);
            return View(tblPayment);
        }

        // POST: Admin/Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,cid,InvTitle,InvDesc,PublishedDate,InvDocument,invStatus,fldextra,fldextra1,fldextra2")] tblPayment tblPayment)
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
                    tblPayment.InvDocument = FileName;
                }
            }
            catch (Exception)
            {


            }



            if (ModelState.IsValid)
            {
                db.Entry(tblPayment).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.UserDetails, "id", "fldName", tblPayment.cid);
            return View(tblPayment);
        }

        // GET: Admin/Payments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment tblPayment = await db.tblPayments.FindAsync(id);
            if (tblPayment == null)
            {
                return HttpNotFound();
            }
            return View(tblPayment);
        }

        // POST: Admin/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblPayment tblPayment = await db.tblPayments.FindAsync(id);
            db.tblPayments.Remove(tblPayment);
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
