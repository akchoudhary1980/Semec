using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.TenderSearchManage.Model
{
    public class TenderSearchLinkModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TenderSearchLinkID { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Please Enter Department Category")]
        [Display(Name = "Department Category")]
        public int DepartmentCategoryID { get; set; }

        [Required(ErrorMessage = "Please Tender Search Website")]
        [Display(Name = "Tender Search Website")]
        public string TenderSearchWebsite { get; set; } // website

        [Required(ErrorMessage = "Please Tender Search Link")]
        [Display(Name = "Tender Search Link")]        
        public string TenderSearchLink { get; set; } // website

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


        [Display(Name = "Logo")]
        public string Logo { get; set; }
    }
}
