using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class SMSSetupModel
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.None)]       
         public int SmsSetupID { get; set; }

         [Display(Name = "SMS Provider Name")]
         public string SMSProviderName { get; set; }

         [Display(Name = "SMS Sender ID")]
         public string Sender { get; set; }

         [Display(Name = "Request ID")]
         public string RequestID { get; set; }

         [Display(Name = "Route ID")]
         public string RouteID { get; set; }

         [Display(Name = "User Name")]
         public string UserName { get; set; }

         [Display(Name = "Password")]
         public string Password { get; set; }

         [Display(Name = "SMS Type")]
         public string SMSType { get; set; }         
    }
}
