using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.DealersManage.Model
{
    public class DealersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealersID { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        [Display(Name = "Company Name")]
        public string Company { get; set; }      


        [Display(Name = "Brand Name")]
        public string Brand { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }


        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }



        //Contact Persion
        [Required(ErrorMessage = "Please Enter Contact Persion")]
        [Display(Name = "Contact Persion")]
        public string CP1 { get; set; }


        [Display(Name = "Contact Persion")]
        public string CP2 { get; set; }

        [Display(Name = "Contact Persion")]
        public string CP3 { get; set; }

        // Mobile 
        [Required(ErrorMessage = "Please Enter Mobile")]
        [Display(Name = "Mobile")]
        public string MobileCP1 { get; set; }

        [Display(Name = "Mobile")]
        public string MobileCP2 { get; set; }

        [Display(Name = "Mobile")]
        public string MobileCP3 { get; set; }

        // Email
        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Email")]
        public string EmailCP1 { get; set; }


        [Display(Name = "Email")]
        public string EmailCP2 { get; set; }

        [Display(Name = "Email")]
        public string EmailCP3 { get; set; }

      


        [Display(Name = "Cataloge")]
        public string Cataloge { get; set; }

        [Display(Name = "Company Logo")]
        public string Logo { get; set; }



        [Display(Name = "Deal In")]
        public string DealIn { get; set; }

    }
}
