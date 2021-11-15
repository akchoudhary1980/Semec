using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class EmailSetupModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int EmailSetupID { get; set; }
        
        [Display(Name = "Email Provider")]
         public string EmailProvider { get; set; }
        
        [Display(Name = "SMTP Host")]
        public string SmtpHost { get; set; }
        
        [Display(Name = "SMTP Port")]
        public string SmtpPort { get; set; }
        
        [Display(Name = "Email From")]
        public string EmailFrom { get; set; }
        
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [Display(Name = "Password")]
        public string Password { get; set; }
        
    }
}
