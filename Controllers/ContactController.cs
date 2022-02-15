using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaburFranchise.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult ContactInformation_Factories()
        {
            return View();
        }

        //public ActionResult Contact_Information_Branch_Offices()
        //{
        //    return View();
        //}

        public ActionResult Contact_Information_Overseas_Offices()
        {
            return View();
        
        }

        public ActionResult Subsidiaries()
        {
            return View();
        }

        public ActionResult Contact_Information_Overseas_business_private_label()
        {
            return View();
        }

    }
}
