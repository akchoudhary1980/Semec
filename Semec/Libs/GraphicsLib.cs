using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;


namespace Semec
{
    public class GraphicsLib
    {
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
            objBitmap.Save(System.Web.HttpContext.Current.Server.MapPath("~/Images/captcha.jpg"), ImageFormat.Jpeg);
        }
    }
}