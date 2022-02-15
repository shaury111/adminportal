
using Ecommerce.Filters;
using SiteAllAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace new_loginsystem.Areas.Admin.Controllers
{
    [AuthorizeUser(Roles = "Admin")]
    public class DashBoardController : Controller
    {

        private JobPortalEntities db = new JobPortalEntities();


        // GET: Admin/DashBoard
        public ActionResult Index()
        {


            ViewBag.totalcustomer = db.UserDetails.Count();
            return View();
        }


        public ActionResult SiteEnquiry()
        {

            DataTable dt = new DataTable();
            string constring = @"Data Source=103.102.234.246;User ID=realme;Password=lGy33$9s; Initial Catalog=RealMePartner;";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SelectFiltereddata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                using (DataTable dt1 = new DataTable())
                {
                    sda.Fill(dt);
                    // dt = dt1;
                }
            }


            //XLWorkbook wb = new XLWorkbook();
            //wb.Worksheets.Add(dt);
            //wb.Name = "my sheet name";

            if (dt.Rows.Count > 0)
            {
                ViewBag.Enqdetauils = dt;

            }


            //wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //wb.Style.Font.Bold = true;
            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment;filename= NewEnquiry.xlsx");

            //MemoryStream MyMemoryStream = new MemoryStream();
            //wb.SaveAs(MyMemoryStream);
            //MyMemoryStream.WriteTo(Response.OutputStream);
            //Response.Flush();
            //Response.End();


            //return View(dt);

            return View();


        }





    }
}