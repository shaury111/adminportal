
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DataAccess.Repository
{
   public interface IEnquiry
    {

        IEnumerable<NewEnquiryies> EnquiryList();
        NewEnquiryies Enquiry(int Id);
        bool DeleteEnquiry(int Id);
        bool MoveEnquiry(int id);



    }
}
