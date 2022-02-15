using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Ecommerce.Utility
{
    public class SMSNotification
    {
        static public string strErr = string.Empty;

        static private string userName = "neerajtxn", password = "529351", senderName = "AMBAZR", authCode;

        static public bool SendSMS(string msgContent, string contactNo)
        {            
            try
            {
                //string createdURL1 = "http://truebulksms.biz/api.php?username=neerajtxn&password=529351&sender=PISYST&sendto=9835059279&message=Patna jn&type=3";
                //string createdURL1 = "http://truebulksms.biz/api.php?username=neerajtxn&password=529351&sender=PISYST&sendto=9835059279&message=Patna jn";
                string createdURL = ""; //"http://truebulksms.biz/api.php?username=" + userName + "&password=" + password + "&sender=" + senderName + "&sendto=" + contactNo + "&message=" + msgContent + "";

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                StreamReader respStreamReader = new StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
                strErr = responseString;

                //if (strErr.Contains("Invalid Request"))
                //if (strErr.Contains("Invalid") || strErr.Contains("Less"))
                if (strErr.Contains("LogID=") == false && strErr.Trim().Length != 19)
                {
                    //throw new Exception(strErr);
                    strErr = responseString;
                    return false;
                }
                else
                {
                    strErr = "Message Sent Successfully...";
                    return true;
                }                
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return false;
            }
        }
    }
}