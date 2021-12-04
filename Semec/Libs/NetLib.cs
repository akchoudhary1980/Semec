using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Net.Mail;
using System.Data;

namespace Semec
{
    public class NetLib
    {
        public static string DetermineCompName(string IP)
        {
            IPAddress myIP = IPAddress.Parse(IP);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
            return compName.First();
        }
        public static bool IsMobileBrowser()
        {
            //GETS THE CURRENT USER CONTEXT
            HttpContext context = HttpContext.Current;

            //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                return true;
            }
            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                return true;
            }
            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
                context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                return true;
            }
            //AND FINALLY CHECK THE HTTP_USER_AGENT 
            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                string[] mobiles =
                    new[]
                {
                    "midp", "j2me", "avant", "docomo",
                    "novarra", "palmos", "palmsource",
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/",
                    "blackberry", "mib/", "symbian",
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio",
                    "SIE-", "SEC-", "samsung", "HTC",
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx",
                    "NEC", "philips", "mmm", "xx",
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java",
                    "pt", "pg", "vox", "amoi",
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo",
                    "sgh", "gradi", "jb", "dddi",
                    "moto", "iphone"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].
                                                        ToLower().Contains(s.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static string GetComputerIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static string GetBrowserDetails()
        {
            string browserDetails = string.Empty;
            System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            browserDetails =
            "Name = " + browser.Browser + "," +
            "Type = " + browser.Type + ","
            + "Version = " + browser.Version + ","
            + "Major Version = " + browser.MajorVersion + ","
            + "Minor Version = " + browser.MinorVersion + ","
            + "Platform = " + browser.Platform + ","
            + "Is Beta = " + browser.Beta + ","
            + "Is Crawler = " + browser.Crawler + ","
            + "Is AOL = " + browser.AOL + ","
            + "Is Win16 = " + browser.Win16 + ","
            + "Is Win32 = " + browser.Win32 + ","
            + "Supports Frames = " + browser.Frames + ","
            + "Supports Tables = " + browser.Tables + ","
            + "Supports Cookies = " + browser.Cookies + ","
            + "Supports VBScript = " + browser.VBScript + ","
            + "Supports JavaScript = " + "," +
            browser.EcmaScriptVersion.ToString() + ","
            + "Supports Java Applets = " + browser.JavaApplets + ","
            + "Supports ActiveX Controls = " + browser.ActiveXControls
            + ","
            + "Supports JavaScript Version = " +
            browser["JavaScriptVersion"];
            return browserDetails;
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static string SendEmailByGmail(string toList, string from, string ccList, string subject, string body)
        {
            DataTable dt = new DataTable();
            dt = DataLib.GetQueryTable("Select * from EmailSetupModels Where EmailSetupID=" + 1, DataLib.cs);
            DataRow dr = dt.Rows[0];

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            string msg = string.Empty;
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
                smtpClient.Host = dr["SmtpHost"].ToString();   // We use gmail as our smtp client
                smtpClient.Port = Convert.ToInt16(dr["SmtpPort"].ToString());
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(dr["UserName"].ToString(), dr["Password"].ToString());

                smtpClient.Send(message);
                msg = "Successful";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;


            //MailMessage message = new MailMessage();
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.EnableSsl = true;
            //string msg = string.Empty;
            //try
            //{
            //    MailAddress fromAddress = new MailAddress(from);
            //    message.From = fromAddress;
            //    message.To.Add(toList);
            //    if (ccList != null && ccList != string.Empty)
            //        message.CC.Add(ccList);
            //    message.Subject = subject;
            //    message.IsBodyHtml = true;
            //    message.Body = body;
            //    smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
            //    smtpClient.Port = 587;
            //    smtpClient.EnableSsl = true;
            //    smtpClient.UseDefaultCredentials = true;
            //    smtpClient.Credentials = new System.Net.NetworkCredential("akchoudhary1980@gmail.com", "b2830619");

            //    smtpClient.Send(message);
            //    msg = "Successful<BR>";
            //}
            //catch (Exception ex)
            //{
            //    msg = ex.Message;
            //}
            //return msg;
        }
        public static void SendEmailByHostCats(string toList, string ccList, string subject, string body, string emailFrom)
        {
            try
            {
                MailMessage msgs = new MailMessage();
                msgs.To.Add("akchoudhary1980@gmail.com"); // 
                MailAddress efrom = new MailAddress(emailFrom);
                msgs.From = efrom; // from  
                msgs.Subject = subject;

                msgs.Body = body;
                msgs.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = "mail.dreamingdesire.in";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("info@dreamingdesire.in", "Anil_1234");
                //Send the msgs  
                client.Send(msgs);
                //  HttpContext.Current. ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Your Details Sent Successfull.');", true);
            }
            catch 
            {

            }
        }
    }
}