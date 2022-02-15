using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System.IO;
using Ecommerce.Filters;
using SiteAllAdmin.Models;

namespace new_loginsystem.Areas.Admin.Controllers
{

    //[Authorize]
    [AuthorizeUser(Roles = "Admin")]
    public class AddNewController : Controller
    {
        private readonly JobPortalEntities db = new JobPortalEntities();

        // GET: Admin/AddNew
        public async Task<ActionResult> Index()
        {
            var userDetails = db.UserDetails.Include(u => u.tblrole);
            return View(await userDetails.ToListAsync());
        }
        

        // GET: Admin/AddNew/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = await db.UserDetails.FindAsync(id);
            ViewBag.Noticelist = db.tblnotifications.Where(x=>x.cid== userDetail.id).ToList();
            ViewBag.totalnotice = db.tblnotifications.Where(x => x.cid == userDetail.id).Count();

            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // GET: Admin/AddNew/Create
        public ActionResult Create()
        {
            ViewBag.roletype = new SelectList(db.tblroles, "fldroleid", "fldrole");
            return View();
        }

        // POST: Admin/AddNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,fldName,fldMobile,fldemail,fldsreet,fldstate,fldcity,fldpincode,fldstorename,fldstoreemail,fldstorecontactno,fldshopcode,fldstoreaddress,fldstorestate,fldstorecity,fldstorepincode,fldpassword,fldstatus,fldcreateddate,fldimage")] UserDetail userDetail)
        {


            userDetail.id = 0;
            userDetail.fldcreateddate = System.DateTime.Now;
            userDetail.roletype = 2;
            string FileName = "";

            HttpPostedFileBase file = Request.Files[0];

            if(file!=null)
            {
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
                //Its Create complete path to store in server.  
                string SaveLocation = Server.MapPath("~/Uploadcpic") + "/" + FileName;
                file.SaveAs(SaveLocation);
                //To copy and save file into server.  
                //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);

            }

            //Add Current Date To Attached File Name  



            userDetail.fldimage = FileName;

            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetail);
                await db.SaveChangesAsync();

                StatusKeyPair obje = new StatusKeyPair {
                    id=userDetail.id,
                    statusKey=userDetail.StatusKey,
                    statusDescription=userDetail.StatusDescription
                };

                db.StatusKeyPairs.Add(obje);
                //await db.SaveChangesAsync();


                return RedirectToAction("Index");
            }

            ViewBag.roletype = new SelectList(db.tblroles, "fldroleid", "fldrole", userDetail.roletype);
            return View(userDetail);
        }

        // GET: Admin/AddNew/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = await db.UserDetails.FindAsync(id);

            ViewBag.statusKeyHistory =  db.StatusKeyPairs.Where(x=>x.cid==id);


            if (userDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.roletype = new SelectList(db.tblroles, "fldroleid", "fldrole", userDetail.roletype);
            return View(userDetail);
        }

        // POST: Admin/AddNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,fldName,fldMobile,fldemail,fldsreet,fldstate,fldcity,fldpincode,fldstorename,fldstoreemail,fldstorecontactno,fldshopcode,fldstoreaddress,fldstorestate,fldstorecity,fldstorepincode,fldpassword,fldstatus,fldcreateddate,fldimage,roletype,StatusKey,StatusDescription")] UserDetail userDetail)
        {
            
            string FileName = "";

            try
            {
                HttpPostedFileBase file = Request.Files[0];

                if (file.FileName!="")
                {
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName;
                    //Its Create complete path to store in server.  
                    string SaveLocation = Server.MapPath("~/Uploadcpic") + "/" + FileName;
                    file.SaveAs(SaveLocation);
                    //To copy and save file into server.  
                    //file.SaveAs(Server.MapPath("~/Uploadcpic/") + FileName);
                    userDetail.fldimage = FileName;
                }
            }
            catch (Exception)
            {

                
            }

            //Add Current Date To Attached File Name  






            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = System.Data.Entity.EntityState.Modified;

                var countstatuskey = db.StatusKeyPairs.Where(x => x.statusKey == userDetail.StatusKey).ToList();

                if (countstatuskey.Count == 0)
                {
                    StatusKeyPair obje = new StatusKeyPair
                    {
                        cid = userDetail.id,
                        statusKey = userDetail.StatusKey,
                        statusDescription = userDetail.StatusDescription
                    };
                    db.StatusKeyPairs.Add(obje);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.roletype = new SelectList(db.tblroles, "fldroleid", "fldrole", userDetail.roletype);
            return View(userDetail);
        }

        // GET: Admin/AddNew/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = await db.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: Admin/AddNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserDetail userDetail = await db.UserDetails.FindAsync(id);
            db.UserDetails.Remove(userDetail);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        [HttpPost]
        public JsonResult DeleteStatus(string id)
        {
            int stid = -2;bool msg = false;
            stid = int.Parse(id);     

            StatusKeyPair stobject =  db.StatusKeyPairs.Find(stid);
            if(stobject!=null)
            {
                db.StatusKeyPairs.Remove(stobject);
                db.SaveChanges();
                msg = true;
            }

            return Json(msg,JsonRequestBehavior.AllowGet);
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
