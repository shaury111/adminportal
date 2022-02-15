using DataAccess;
using DataAccess.Repository;
using SiteAllAdmin.Resource;
using SiteCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SiteCMS.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private IEnquiry _enquiry = new EnquiryHub();

        // GET: Admin
        public ActionResult Index()
        {

            return View(EnquiryList());
        }

        public ActionResult Details(int id)
        {
            var item= _enquiry.Enquiry(id);
             var Details=  new EnquiryiesViewModel
            {
                id = item.id,
                ApplyFor = item.ApplyFor,
                CurentCity = item.CurentCity,
                CustomerName = item.CustomerName,
                Customer_Email = item.Customer_Email,
                customer_monthly_Income = item.customer_monthly_Income,
                Customer_phone = item.Customer_phone,
                EntryDate = item.EntryDate,
                fldextra = item.fldextra,
                fldextra1 = item.fldextra1,
                fldextra2 = item.fldextra2,
                invest_amount = item.invest_amount,
                stateresidance = item.stateresidance,
            };

            return View(Details);
        
        }

        //[HttpPost]
        public ActionResult MoveToCustomer(int id)
        {

            bool IsMoved = _enquiry.MoveEnquiry(id);
            return RedirectToAction(Webresourse.Index, Webresourse.AdminController);
        }






            private IEnumerable<EnquiryiesViewModel> EnquiryList()
        {
            List<EnquiryiesViewModel> enquiryiesViewModels = new List<EnquiryiesViewModel>();
            var EnquiryList = _enquiry.EnquiryList();
            foreach(var item in EnquiryList)
            {
                enquiryiesViewModels.Add(new EnquiryiesViewModel {
                    id = item.id,
                    ApplyFor = item.ApplyFor,
                    CurentCity = item.CurentCity,
                    CustomerName = item.CustomerName,
                    Customer_Email = item.Customer_Email,
                    customer_monthly_Income = item.customer_monthly_Income,
                    Customer_phone = item.Customer_phone,
                    EntryDate = item.EntryDate,
                    fldextra = item.fldextra,
                    fldextra1 = item.fldextra1,
                    fldextra2 = item.fldextra2,
                    invest_amount = item.invest_amount,
                    stateresidance = item.stateresidance,

                });
            }

            return enquiryiesViewModels;
        }
    }
}