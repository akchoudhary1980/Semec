using Semec.Areas.CommonManage.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Semec.Controllers
{
    public class SetupController : Controller
    {
        // GET: Setup
        public MyContext db = new MyContext();
        public ActionResult DatabaseForm()
        {
            return RedirectToAction("SetupProcess", "Setup");
        }
        public ActionResult SetupProcess()
        {           
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("~/App_Data/SetupModel.xml"));
            XmlNodeList setup = xDoc.GetElementsByTagName("Setup");
            string Setup = setup[0].InnerText;
            //database form if no database 
            //using (SqlConnection con = new SqlConnection("String"))
            //{
            //    using (SqlCommand cmd = new SqlCommand("Query"))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            // End 

            if (Setup.Equals("No"))
            {
                // code Here
                InsertUser();
                InsertCompany();
                InsertCity();
                InsertState();
                InsertCountry();
                InsertProfession();
                // Reset the sml file
                XmlDocument xDoc1 = new XmlDocument();
                xDoc1.Load(Server.MapPath("~/App_Data/SetupModel.xml"));
                xDoc1.SelectSingleNode("SetupStatus/Setup").InnerText = "Yes";
                xDoc1.Save(Server.MapPath("~/App_Data/SetupModel.xml"));
            } 
            // Reset the session          
            return RedirectToAction("Index", "Home");
        }

        public void InsertUser()
        {
            // remove all records
            var all = db.UserModels.ToList(); 
            db.UserModels.RemoveRange(all);
            db.SaveChanges();

            UserModel u = new UserModel
            {
                UserID = 1,
                UserName = "9039914956",
                Mobile = "9039914956",
                Password = "Temp",
                DisplayName = "Anil Choudhary",
                Email = "akchoudhary1980@gmail.com",
                UserType = "Admin",
                AccountStatus = "Active",
                ReadRights = true,
                WrightRights = true,
                SettingRights = true,
                UserPicture = "User1.jpg"
            };
            db.UserModels.Add(u);
            db.SaveChanges();
        }
        public void InsertCompany()
        {
            // remove all records
            var all = db.CompanyModels.ToList();
            db.CompanyModels.RemoveRange(all);
            db.SaveChanges();

            CompanyModel c = new CompanyModel
            {
                CompanyID = 1,
                CompanyName = "True Logic India",
                CompanyAddress = "72 Meerganj Colony, Bheraghat Road, Jabalpur (MP)",
                CompanyState = "Madhya Pradesh",
                CompanyCity = "Jabalpur",
                OnwerName = "Anil Choudhary",
                ContactPerson = "Anil Choudhary",
                CompanyMobile = "9039914956",
                CompanyWhatsup = "9039914956",
                CompanyEmail = "akchoudhary1980@gmail.com",
                DateofRegistration = DateTime.Today,
                GST = "23AGRPT2719C1ZC",
                InvoicePrefix = "TL",
                InvoiceNumber = 1,
                QuotationNumber = 1,
                PurchaseNumber = 1,
                CompanyPicture = "Company1.jpg",
                SealPicture = "CompanySeal1.jpg"
            };
            db.CompanyModels.Add(c);
            db.SaveChanges();
        }        
        public void InsertCountry()
        {
            // remove all records
            var all = db.CountryModels.ToList(); // from c in dataDb.Table select c;
            db.CountryModels.RemoveRange(all);
            db.SaveChanges();
            // insert in bulk
            using (var db = new MyContext())
            {
                var country = GetCountryList();
                db.CountryModels.AddRange(country);
                db.SaveChanges();
            }
        }
        public void InsertState()
        {
            // remove all records
            var all = db.StateModels.ToList(); // from c in dataDb.Table select c;
            db.StateModels.RemoveRange(all);
            db.SaveChanges();

            // insert in bulk
            using (var db = new MyContext())
            {
                var state = GetStateList();
                db.StateModels.AddRange(state);
                db.SaveChanges();
            }
        }
        public void InsertCity()
        {
            // remove all records
            var all = db.CityModels.ToList(); // from c in dataDb.Table select c;
            db.CityModels.RemoveRange(all);
            db.SaveChanges();

            // insert in bulk
            using (var db = new MyContext())
            {
                var city = GetCityList();
                db.CityModels.AddRange(city);
                db.SaveChanges();
            }
        }
        public void InsertProfession()
        {
            // remove all records
            var all = db.ProfessionModels.ToList(); // from c in dataDb.Table select c;
            db.ProfessionModels.RemoveRange(all);
            db.SaveChanges();

            // insert in bulk
            using (var db = new MyContext())
            {
                var pro = GetProfessionList();
                db.ProfessionModels.AddRange(pro);
                db.SaveChanges();
            }
        }

        public static List<CityModel> GetCityList()
        {
            List<CityModel> citylist = new List<CityModel>();
            DataTable dt = ReadXML("City");
            foreach (DataRow dr in dt.Rows)
            {
                CityModel c = new CityModel
                {
                    CityID = Convert.ToInt32(dr["CityID"]),
                    CityName = dr["CityName"].ToString(),
                    StateID = Convert.ToInt32(dr["StateID"].ToString())

                };
                citylist.Add(c);
            }
            return citylist;
        }
        public static List<StateModel> GetStateList()
        {
            List<StateModel> statelist = new List<StateModel>();
            DataTable dt = ReadXML("State");
            foreach (DataRow dr in dt.Rows)
            {
                StateModel s = new StateModel
                {
                    StateID = Convert.ToInt32(dr["StateID"]),
                    StateName = dr["StateName"].ToString(),
                    StateType = dr["StateType"].ToString(),
                    CountryID = Convert.ToInt32(dr["CountryID"].ToString())
                };
                statelist.Add(s);
            }
            return statelist;
        }
        public static List<CountryModel> GetCountryList()
        {
            List<CountryModel> countrylist = new List<CountryModel>();
            DataTable dt = ReadXML("Country");
            foreach (DataRow dr in dt.Rows)
            {
                CountryModel c = new CountryModel
                {
                    CountryID = Convert.ToInt32(dr["CountryID"]),
                    CountryName = dr["CountryName"].ToString(),
                    Region = dr["Region"].ToString()
                };
                countrylist.Add(c);
            }
            return countrylist;
        }
        public static List<ProfessionModel> GetProfessionList()
        {
            List<ProfessionModel> prolist = new List<ProfessionModel>();
            DataTable dt = ReadXML("Profession");
            foreach (DataRow dr in dt.Rows)
            {
                ProfessionModel c = new ProfessionModel
                {
                    ProfessionID = Convert.ToInt32(dr["ProfessionID"]),
                    ProfessionName = dr["ProfessionName"].ToString(),  
                };
                prolist.Add(c);
            }
            return prolist;
        }
        public static DataTable ReadXML(string file)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + file + ".xml"));
            ds.Dispose();
            return ds.Tables[0];
        }
    }
}