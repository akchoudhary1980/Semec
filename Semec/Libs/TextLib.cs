using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Semec
{
    public class TextLib
    {
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
        public static string GetDeviceType()
        {
            string device = "";
            if (HttpContext.Current.Request.Browser.IsMobileDevice)
            {
                device = "Mobile";
            }
            else
            {
                device = "Desktop";
            }
            return device;
        }
        public static string GetBrowserName()
        {
            string browserName = HttpContext.Current.Request.Browser.Browser;
            return browserName;
        }
        //public async static string GetLocation()
        //{
        //    ////this line is to check the clien ip address from the server itself
        //    string IP = "";
        //    string strHostName = "";
        //    strHostName = System.Net.Dns.GetHostName();
        //    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
        //    IPAddress[] addr = ipEntry.AddressList;
        //    IP = addr[2].ToString();
        //    ///
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri("https://ip-geo-location.p.rapidapi.com/ip/23.123.12.11?format=json"),
        //        Headers =
        //            {
        //            { "x-rapidapi-key", "da2d9d1504msh65a06a4f5ef52dfp1b43e1jsn63d501e1d579" },
        //            { "x-rapidapi-host", "ip-geo-location.p.rapidapi.com" },
        //            },
        //    };
        //    List<string> ParaMeter = List<string>();

        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        //Console.WriteLine(body);
        //        ParaMeter.Add(body);
        //    }

        //    ParaMeter.Add("Anil");
        //    return "location";
        //}
        public static string GetUserPlatform(HttpRequest request)
        {
            var ua = request.UserAgent;

            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";

            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

            if (ua.Contains("Mac OS"))
                return "Mac OS";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                return "Windows 10";
            //fallback to basic platform:
            return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
        }
        public static string GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }
        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        public static string GetMachineName(string IP)
        {
            try
            {
                //IPAddress myIP = IPAddress.Parse(IP);
                //IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                //List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                //return compName.First();


                string[] computer_name = System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                String ecname = System.Environment.MachineName;
                return computer_name[0].ToString();

                //string PCName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;
                //return System.Net.Dns.GetHostName();
            }
            catch
            {
                return "Unknown";
            }
            

           
        }


        public static string GeneratOTP()
        {
            Random r = new Random();
            return r.Next(1000, 9999).ToString();
        }
        public static int GetMaxDataTableColoumn(DataTable dt,string column)
        {
            try
            {
                return Convert.ToInt32(dt.Compute("max(["+ column + "])", string.Empty));
            }
            catch
            {
                return 0;
            }            
        }
        public static string Encrypt(string Text)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(Text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    Text = Convert.ToBase64String(ms.ToArray());
                }
            }
            return Text;
        }
        public static string Decrypt(string Text)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            Text = Text.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(Text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    Text = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return Text;
        }
        public static string GetCaptcha()
        {
            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);

            return finalString;
        }
        public static void DrawCaptch(string captcha)
        {
            Bitmap objBitmap;
            Graphics objGraphics;
            objBitmap = new Bitmap(100, 35);
            objGraphics = Graphics.FromImage(objBitmap);
            objGraphics.Clear(Color.White);

            Pen redPen = new Pen(Color.Red, 1);
            objGraphics.DrawLine(redPen, 5, 4, 95, 32);

            FontFamily fontfml = new FontFamily(GenericFontFamilies.Serif);
            Font font = new Font(fontfml, 16);
            SolidBrush brush = new SolidBrush(Color.Green);
            objGraphics.DrawString(captcha, font, brush, 5, 5);


            objBitmap.Save(System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/captcha.jpg"), ImageFormat.Jpeg);
        }
        public static string UnicodeToUTF8(string myString)
        {
            byte[] utfByte = Encoding.UTF8.GetBytes(myString);
            HttpUtility.UrlEncode(utfByte);
            return HttpUtility.UrlEncode(utfByte);
        }
        public static void SendSMS1(string SentTo, string Message, string Type)
        {
            DataTable dt = new DataTable();
            dt = DataLib.GetQueryTable("Select * from SmsSetupModels Where SmsSetupID=" + 1);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string strUrl = "";

                if (Type == "Unicode")
                {
                    strUrl = "http://login.heightsconsultancy.com/API/WebSMS/Http/v1.0a/index.php?username=" + dr["UserName"].ToString() + "&password=" + dr["Password"].ToString() + "&sender=" + dr["Sender"].ToString() + "&to=" + SentTo + "&message=" + Message + "&reqid=1&format={json|text}&route_id=113&msgtype=unicode";
                }
                else
                {
                    strUrl = "http://login.heightsconsultancy.com/API/WebSMS/Http/v1.0a/index.php?username=" + dr["UserName"].ToString() + "&password=" + dr["Password"].ToString() + "&sender=" + dr["Sender"].ToString() + "&to=" + SentTo + "&message=" + Message + "&reqid=1&format={json|text}&route_id=113";
                }
                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString(strUrl);
                }
            }
        }
        public static void SendSMS(string SentTo, string Message, string Type)
        {


           // string strUrl = "http://jskbulkmarketing.in/app/smsapi/index.php?key=45FBBA10755DCC&entity=&tempid=999999999999999&routeid=569&type=text&contacts=" + SentTo + "&senderid=NPIIND&msg=" + Message;

            //"=9827087755,8291008212&senderid=IALERT&msg=Hello+People%2C+have+a+great+day

            //string strUrl = "http://jskbulkmarketing.in/app/smsapi/index.php?key=45FBBA10755DCC&routeid=569&type=text&contacts=" + SentTo + "&senderid=NPIIND&msg=" + Message; IALERT

            string strUrl = "http://jskbulksms.in/app/smsapi/index.php?key=36055BE5C4AB2B&campaign=1&routeid=46&type=text&contacts=" + SentTo + "&senderid=NILAYU&msg=" + Message;
            // Send 
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString(strUrl);
            }

           
        }

        public static void SendSMS(string Message)
        {
            string strUrl = Message;
            // Send 
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString(strUrl);
            }
        }
        public static void SendWhatsup(string WhatsupMobile, string Message)
        {
            //Response.Write("<script>window.open('file.pdf',target='new');</script>");
                string strUrl = "https://api.whatsapp.com/send?phone=" + WhatsupMobile + "&text=" + Message;           
                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString(strUrl);
                }            
        }
        public static string GetMultipleLine(string text)
        {
            string[] lines = Regex.Split(text, "\r\n");
            string str = "";
            for (int i = 0; i < lines.Length; i++)
            {
                str = str + lines[i] + "\r\n";
            }
            str = str.Substring(0, str.Length - 2);
            return str;
        }
        public static string WordMore(string words, int count)
        {
            words = GetMultipleLine(words);
            if (words.Length > count)
            {
                words = words.Substring(0, count);
                words = words + ".....";
                return words;
            }
            else
            {
                words = words + ".....";
                return words;
            }

        }
        public static string NumbertoWards(string NumStr)
        {
            string Result = "";

            if (NumStr.Contains('.') == true)
            {
                // Eliminate 
                int idx = NumStr.IndexOf('.');
                NumStr = NumStr.Substring(0, idx);
            }

            // main logic 
            int len = NumStr.Length;
            do
            {
                switch (len)
                {
                    case 1:
                        Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr));
                        NumStr = "";
                        break;
                    case 2:
                        Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr));
                        NumStr = "";
                        break;
                    case 3:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 2);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 1))) + " Hundred ";
                            NumStr = NumStr.Substring(1, 2);
                        }
                        break;
                    case 4:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 3);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 1))) + " Thousand ";
                            NumStr = NumStr.Substring(1, 3);
                        }
                        break;
                    case 5:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 4);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 2))) + " Thousand ";
                            NumStr = NumStr.Substring(2, 3);
                        }
                        break;
                    case 6:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 5);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 1))) + " Lakh ";
                            NumStr = NumStr.Substring(1, 5);
                        }
                        break;
                    case 7:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 6);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 2))) + " Lakh ";
                            NumStr = NumStr.Substring(2, 5);
                        }
                        break;
                    case 8:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 7);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 1))) + " Crore ";
                            NumStr = NumStr.Substring(1, 7);
                        }
                        break;
                    case 9:
                        if (NumStr.Substring(0, 1) == "0")
                        {
                            NumStr = NumStr.Substring(1, 8);
                        }
                        else
                        {
                            Result = Result + TwoDigitNumber(Convert.ToInt16(NumStr.Substring(0, 2))) + " Crore ";
                            NumStr = NumStr.Substring(2, 7);
                        }
                        break;

                }
                len = NumStr.Length;

            } while (len != 0);

            return Result + " Rupee Only";
        }
        private static string TwoDigitNumber(int ind)
        {
            List<string> Counting = new List<string>
            {
                "",
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Eleven",
                "Twelve",
                "Thirteen",
                "Fourteen",
                "Fifteen",
                "Sixteen",
                "Seventeen",
                "Eighteen",
                "Nineteen",
                "Twenty",
                "Twenty One",
                "Twenty Two",
                "Twenty Three",
                "Twenty Four",
                "Twenty Five",
                "Twenty Six",
                "Twenty Seven",
                "Twenty Eight",
                "Twenty Nine",
                "Thirty",
                "Thirty One",
                "Thirty Two",
                "Thirty Three",
                "Thirty Four",
                "Thirty Five",
                "Thirty Six",
                "Thirty Seven",
                "Thirty Eight",
                "Thirty Nine",
                "Forty",
                "Forty One",
                "Forty Two",
                "Forty Three",
                "Forty Four",
                "Forty Five",
                "Forty Six",
                "Forty Seven",
                "Forty Eight",
                "Forty Nine",
                "Fifty",
                "Fifty One",
                "Fifty Two",
                "Fifty Three",
                "Fifty Four",
                "Fifty Five",
                "Fifty Six",
                "Fifty Seven",
                "Fifty Eight",
                "Fifty Nine",
                "Sixty",
                "Sixty One",
                "Sixty Two",
                "Sixty Three",
                "Sixty Four",
                "Sixty Five",
                "Sixty Six",
                "Sixty Seven",
                "Sixty Eight",
                "Sixty Nine",
                "Seventy",
                "Seventy One",
                "Seventy Two",
                "Seventy Three",
                "Seventy Four",
                "Seventy Five",
                "Seventy Six",
                "Seventy Seven",
                "Seventy Eight",
                "Seventy Nine",
                "Eighty",
                "Eighty One",
                "Eighty Two",
                "Eighty Three",
                "Eighty Four",
                "Eighty Five",
                "Eighty Six",
                "Eighty Seven",
                "Eighty Eight",
                "Eighty Nine",
                "Ninety",
                "Ninety One",
                "Ninety Two",
                "Ninety Three",
                "Ninety Four",
                "Ninety Five",
                "Ninety Six",
                "Ninety Seven",
                "Ninety Eight",
                "Ninety Nine",
                "Hundred"
            };
            return Counting[ind];
        }
        public static double GetDouble(string str)
        {
            try
            {
                double d;
                double.TryParse(str, out d);
                return d;
            }
            catch
            {
                return 0;
            }           
        }
        public static int GetIntger(string str)
        {
           try
            { 
                int value;
                int.TryParse(str, out value);
                return value;
            }
           catch
            {
                return 0;
            }

        }
        public static decimal GetDecimal(string str)
        {
            try
            {
                decimal value;
                decimal.TryParse(str, out value);
                return value;
            }
            catch
            {
                return 0;
            }
        }
        public static string RemoveBracket(string str)
        {
            string c = ""; string s = "";
            int i = 0;
            while (c != "(")
            {
                c = str.Substring(i, 1);
                s = s + c;
                i++;
            }
            s = s.Substring(0, i - 1);
            return s;

        }
        public static string GetLeftDate(MvcHtmlString date)
        {
            string dt = date.ToString();
            return dt.Substring(0,10);
        }
        public static string GetDateDDMMYYYY(string date)
        {
            return Convert.ToDateTime(date).ToString("dd-MM-yyyy");
        }
        public static string GetDateDDMMYYYY(MvcHtmlString date)
        {
            //DateTime dt;
            //DateTime.TryParseExact(date.ToString(), "MM/dd/yyyy hh:mm:ss tt", new CultureInfo("en-US"), DateTimeStyles.None, out dt);
            //string text = dt.ToString("dd-MM-yyyy", new CultureInfo("en-US"));

            //return text;
            ///
            string dt = date.ToString();
            return Convert.ToDateTime(dt).ToString("dd-MM-yyyy");
        }
        public static string GetTimeHHMM(MvcHtmlString date)
        {
            string dt = date.ToString();
            return Convert.ToDateTime(dt).ToString("hh:mm");
        }
        public static string GetTimeHHMM(TimeSpan? time)
        {
            string dt = time.ToString();
            return Convert.ToDateTime(dt).ToString("hh:mm");
        }
        public static DateTime SetDateDDMMYYYY(string date)
        {
            DateTime dt;
            if (date != "")
            {
                dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else
            {
                dt = DateTime.ParseExact("01-01-1990", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
        }
        public static string IndianRuppes(double Amount)
        {
            decimal Value = decimal.Parse(Amount.ToString(), CultureInfo.InvariantCulture);
            CultureInfo indian = new CultureInfo("hi-IN");
            return string.Format(indian, "{0:c}", Value);
        }
        public static string IndianRuppes(string Amount)
        {
            if(Amount=="")
            {
                Amount = "0";
            }
            decimal Value = decimal.Parse(Amount, CultureInfo.InvariantCulture);
            CultureInfo indian = new CultureInfo("hi-IN");
            return string.Format(indian, "{0:c}", Value);
        }
        public static string IndianRuppes(MvcHtmlString Amount)
        {           
            decimal Value = decimal.Parse(Amount.ToString(), CultureInfo.InvariantCulture);
            CultureInfo indian = new CultureInfo("hi-IN");
            return string.Format(indian, "{0:c}", Value);
        }
        public static string RemoveIndianRuppes(string Amount)
        {
            Amount = Amount.Replace(",", "");
            Amount = Amount.Replace("₹", "");           
            return Amount;
        }
        public static double RemoveIndianCulture(string Amount)
        {
            Amount = Amount.Replace(",", "");
            Amount = Amount.Replace("₹", "");
            return Convert.ToDouble(Amount);
        }
        public static string UploadFilewithHTMLControl(string HTMLControlName, string NewFileName)
        {
            //form should have:-  enctype="multipart/form-data".
            // use readURL for upload and show file.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[HTMLControlName];

            try
            {
                // get details
                string oldfilename = Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                NewFileName = NewFileName + extension;
                //upload file
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    string filePath = HttpContext.Current.Server.MapPath("~/TempFiles/") + Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    // Copy and Delete File
                    File.Copy(HttpContext.Current.Server.MapPath("/TempFiles/" + oldfilename), HttpContext.Current.Server.MapPath("/UploadFiles/" + NewFileName), true);
                    File.Delete(HttpContext.Current.Server.MapPath("~/TempFiles/" + oldfilename));
                    return NewFileName;
                }
                else
                {
                    return "No";
                }
                // rename file
                //if (File.Exists(HttpContext.Current.Server.MapPath("~/TempFiles/" + oldfilename)))
                //{
                //    File.Copy(HttpContext.Current.Server.MapPath("/TempFiles/" + oldfilename), HttpContext.Current.Server.MapPath("/UploadFiles/" + NewFileName), true);
                //    File.Delete(HttpContext.Current.Server.MapPath("~/TempFiles/" + oldfilename));
                //}
                
            }
            catch
            {
                return "No";
            }
        }
        public static string SendMail(string toList,string ccList, string subject, string body)
        {
            DataTable dt = new DataTable();
            dt = DataLib.GetQueryTable("Select * from EmailSetupModels Where EmailSetupID=" + 1);
            DataRow dr = dt.Rows[0];

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(dr["EmailFrom"].ToString());
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
        public static void WriteXML(DataTable dt, string file)
        {
            DataSet ds = new DataSet();
            DataTable table = dt.Copy();           
            ds.Tables.Add(table);
            ds.AcceptChanges();
            ds.WriteXml(System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/Data/" + file + ".xml"));
            ds.Dispose();
        }
        public static DataTable ReadXML(string file)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/Data/" + file + ".xml"));
            ds.Dispose();
            return ds.Tables[0];
        }
        public static void CSHTMLtoHTML(string sourceASPX, string destinationHTML)
        {
            WebRequest mywebReq;
            WebResponse mywebResp;
            StreamReader sr;
            string strHTML;
            StreamWriter sw;
            // Create a HTML Page         
            mywebReq = WebRequest.Create(sourceASPX);
            mywebResp = mywebReq.GetResponse();
            sr = new StreamReader(mywebResp.GetResponseStream());
            strHTML = sr.ReadToEnd();
            sw = File.CreateText(destinationHTML);
            sw.WriteLine(strHTML);
            sw.Close();
        }
        //public static void HTMLtoPDF(string sourceHTML, string destinationPDF)
        //{
        //    HtmlToPdf converter = new HtmlToPdf();
        //    converter.Options.MarginLeft = 10;
        //    converter.Options.MarginRight = 10;
        //    converter.Options.MarginTop = 10;
        //    converter.Options.MarginBottom = 10;
        //    converter.Options.WebPageWidth = 1024;
        //    converter.Options.WebPageHeight = 1250;
        //    string url = sourceHTML;
        //    PdfDocument doc = converter.ConvertUrl(url);
        //    doc.Save(destinationPDF);
        //    doc.Close();
        //}
        //public static void HTMLtoPDFThermalPrinter(string sourceHTML, string destinationPDF)
        //{
        //    ///A standard A4 page has 595 x 842 points.
        //    HtmlToPdf converter = new HtmlToPdf();

        //    converter.Options.PdfPageSize = PdfPageSize.Custom;
        //    converter.Options.PdfPageCustomSize = new SizeF(204, 595); // 72mm x 210mm  
           
        //    converter.Options.MarginLeft = 1;
        //    converter.Options.MarginRight = 1;
        //    converter.Options.MarginTop = 1;
        //    converter.Options.MarginBottom = 1;

        //    converter.Options.WebPageWidth = 204;
        //    converter.Options.WebPageHeight = 595;

        //    string url = sourceHTML;
        //    PdfDocument doc = converter.ConvertUrl(url);
        //    doc.Save(destinationPDF);
        //    doc.Close();
        //}
        public static void OpenPDFNewTab()
        {
            //Content("<script>window.open('{url}','_blank')</script>");
            HttpContext.Current.Response.Write("<script>window.open ('PdfOpen.aspx','_blank');</script>");
        }

        public static string GetCurrentWebsiteRoot()
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        }
        public static string StringFixLength(string str,int fixlength)
        {
            string mystr = str;
            if(mystr.Length> fixlength)
            {
                mystr = mystr.Substring(0, fixlength) + "..";
            }           
            return mystr;
        }
    }
}