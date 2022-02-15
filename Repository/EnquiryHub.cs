
using SiteAllAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ViewModels;

namespace DataAccess.Repository
{
    public class EnquiryHub :IEnquiry
    {

        private JobPortalEntities MyDbContext = new JobPortalEntities();
        public bool DeleteEnquiry(int Id)
        {
            bool flag = false;

            var EnquiryTobedelted = MyDbContext.tblLiveEnquiries.Where(x => x.id == Id).FirstOrDefault();
            if (EnquiryTobedelted != null)
            {
                MyDbContext.tblLiveEnquiries.Remove(EnquiryTobedelted);
                MyDbContext.SaveChanges();
            }

            return flag;
        }
        public NewEnquiryies Enquiry(int Id)
        {
            var Enquiry = MyDbContext.tblLiveEnquiries.Where(x => x.id == Id).FirstOrDefault();
            if (Enquiry != null)
            {
                return new NewEnquiryies
                {
                    id = Enquiry.id,
                    ApplyFor = Enquiry.ApplyFor,
                    CurentCity = Enquiry.CurentCity,
                    CustomerName = Enquiry.CustomerName,
                    Customer_Email = Enquiry.Customer_Email,
                    customer_monthly_Income = Enquiry.customer_monthly_Income,
                    Customer_phone = Enquiry.Customer_phone,
                    EntryDate = Enquiry.EntryDate,
                    fldextra = Enquiry.fldextra,
                    fldextra1 = Enquiry.fldextra1,
                    fldextra2 = Enquiry.fldextra2,
                    invest_amount = Enquiry.invest_amount,
                    stateresidance = Enquiry.stateresidance,
                };
            }
            return null;
        }
        public IEnumerable<NewEnquiryies> EnquiryList()
        {
            List<NewEnquiryies> newEnquiryies = new List<NewEnquiryies>();
            var Enqlist = MyDbContext.tblLiveEnquiries.Where(x=>x.fldextra != "Moved").ToList();
            foreach (var item in Enqlist)
            {
                newEnquiryies.Add(new NewEnquiryies
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

                });
            }
            return newEnquiryies;
        }
        public bool MoveEnquiry(int id)
        {
            bool Flag = false;

            var Enquiry = this.Enquiry(id);
            if (Enquiry != null)
            {
                var getDetails = MyDbContext.tblLiveEnquiries.Where(x => x.id == id).FirstOrDefault();
                getDetails.fldextra = "Moved";
                getDetails.fldextra1 = "Moved Date: "+DateTime.Now.ToString();
                MyDbContext.tblLiveEnquiries.Add(getDetails);
                MyDbContext.Entry(getDetails).State = EntityState.Modified;
                var userdetails = new UserDetail
                {
                    fldName = getDetails.CustomerName,
                    fldcity = getDetails.CurentCity,
                    fldemail = getDetails.Customer_Email,
                    fldMobile = getDetails.Customer_phone,
                    fldcreateddate = DateTime.UtcNow,
                    fldpassword = GeneratePassword(6),
                    roletype=2,
                    fldstatus=false,


                };
                MyDbContext.UserDetails.Add(userdetails);
                MyDbContext.SaveChanges();

            }
            return Flag;

        }
        private string GeneratePassword(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }


}
