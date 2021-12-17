using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.TenderQuoteManage.Model
{
    public class TenderQuoteLinkModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TenderQuoteLinkID { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Please Enter Department Category")]
        [Display(Name = "Department Category")]
        public int DepartmentCategoryID { get; set; }

        [Required(ErrorMessage = "Please Tender Quote Website")]
        [Display(Name = "Tender Quote Website")]
        public string TenderQuoteWebsite { get; set; } // website

        [Required(ErrorMessage = "Please Tender Quote Link")]
        [Display(Name = "Tender Quote Link")]        
        public string TenderQuoteLink { get; set; } // website

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "DSC Name")]
        public string DSCName { get; set; }

        [Display(Name = "DSC Password")]
        public string DSCPassword { get; set; }


        [Display(Name = "Browser Name")]
        public string BrowserName { get; set; }


        [Display(Name = "Logo")]
        public string Logo { get; set; }
    }
}
