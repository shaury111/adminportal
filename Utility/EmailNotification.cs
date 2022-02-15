using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace Ecommerce.Utility
{
    public class EmailNotification
    {
        public static void SendMail(string recipientAddress, string emailSubject, string emailBody)
        {
            emailBody = emailBody.Replace("_RouteUrlPath", System.Configuration.ConfigurationManager.AppSettings["ApplicationRootUrl"]);
            var EmailRecipientList = recipientAddress.Split(',');
            SmtpClient smtp = new SmtpClient();
            MailMessage mail = new MailMessage();
            mail.Body = emailBody;
            mail.Subject = emailSubject;
            foreach (var user in EmailRecipientList)
                mail.To.Add(new MailAddress(user.ToString()));
            mail.IsBodyHtml = true;
            smtp.Send(mail);
        }

        static public string SendMail_GoDaddy(string toList, string ccList, string subject, string body)
        {
            #region pwd
             //admin@ambazzar.com --> welcome!123
             //info@ambazzar.com  --> welcome!456
            #endregion


            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            //string msg = string.Empty, from = "info@ambazzar.com";
            string msg = string.Empty, from = "", pwd = "";

            from = System.Configuration.ConfigurationManager.AppSettings["Info_Mail_Id"].ToString();
            pwd = System.Configuration.ConfigurationManager.AppSettings["Info_Mail_Pwd"].ToString();

            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                smtpClient.Host = "relay-hosting.secureserver.net";   //-- Donot change.
                //smtpClient.Host = "smtpout.asia.secureserver.net";   //-- Donot change.
                smtpClient.Port = 25; //--- Donot change
                smtpClient.EnableSsl = false;//--- Donot change
                smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = new System.Net.NetworkCredential(from, "12345678@mk");
                smtpClient.Credentials = new System.Net.NetworkCredential(from, pwd);

                smtpClient.Send(message);                
                msg = "Successful";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        static public string SendMail_GoDaddy(string toList, string ccList, string subject, string body, ArrayList attachments)
        {
            #region pwd
            //admin@ambazzar.com --> welcome!123
            //info@ambazzar.com  --> welcome!456
            #endregion
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty, from = "", pwd = "";

            from = System.Configuration.ConfigurationManager.AppSettings["Info_Mail_Id"].ToString();
            pwd = System.Configuration.ConfigurationManager.AppSettings["Info_Mail_Pwd"].ToString();

            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                foreach (string attach in attachments)
                {
                    Attachment attached = new Attachment(attach,
                    MediaTypeNames.Application.Octet);
                    //Attachment attached = new Attachment(attach);
                    message.Attachments.Add(attached);
                }

                smtpClient.Host = "relay-hosting.secureserver.net";   //-- Donot change.
                smtpClient.Port = 25; //--- Donot change
                smtpClient.EnableSsl = false;//--- Donot change
                smtpClient.UseDefaultCredentials = true;                
                smtpClient.Credentials = new System.Net.NetworkCredential(from, pwd);

                smtpClient.Send(message);

                msg = "Successful";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        static public string SendMail_Gmail(string toList, string ccList, string subject, string body)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty, from = "ambazzar.com@gmail.com";
            //string msg = string.Empty, from = "testingonlyformail@gmail.com";
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = new System.Net.NetworkCredential(from, "12345678@mk");
                smtpClient.Credentials = new System.Net.NetworkCredential(from, "Ambazzar@123");

                smtpClient.Send(message);

                msg = "Successful";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    msg = ex.InnerException.ToString();
                else
                    msg = ex.Message;
            }
            return msg;
        }

        static public string SendMail_Gmail(string toList, string ccList, string subject, string body, ArrayList attachments)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty, from = "ambazzar.com@gmail.com";
            //string msg = string.Empty, from = "testingonlyformail@gmail.com";
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                foreach (string attach in attachments)
                {
                    Attachment attached = new Attachment(attach,
                    MediaTypeNames.Application.Octet);
                    //Attachment attached = new Attachment(attach);
                    message.Attachments.Add(attached);
                }

                smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = new System.Net.NetworkCredential(from, "12345678@mk");
                smtpClient.Credentials = new System.Net.NetworkCredential(from, "Ambazzar@123");

                smtpClient.Send(message);

                msg = "Successful";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}