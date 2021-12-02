using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class DealersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealersID { get; set; }

        [Display(Name = "Company Name")]
        public int Company { get; set; }

        [Display(Name = "Company Logo")]
        public int Logo { get; set; }

        [Display(Name = "Brand Name")]
        public int Brand { get; set; }

        [Display(Name = "State")]
        public int State { get; set; }

        [Display(Name = "City")]
        public int City { get; set; }

        [Display(Name = "Address")]
        public int Address { get; set; }

        //Contact Persion
        [Display(Name = "CP1")]
        public int CP1 { get; set; }

        [Display(Name = "CP2")]
        public int CP2 { get; set; }

        [Display(Name = "CP3")]
        public int CP3 { get; set; }
        
        // Mobile 
        [Display(Name = "MobileCP1")]
        public int MobileCP1 { get; set; }

        [Display(Name = "MobileCP2")]
        public int MobileCP2 { get; set; }

        [Display(Name = "MobileCP3")]
        public int MobileCP3 { get; set; }
        
        // Email
        [Display(Name = "EmailCP1")]
        public int EmailCP1 { get; set; }

        [Display(Name = "EmailCP3")]
        public int EmailCP2 { get; set; }

        [Display(Name = "EmailCP3")]
        public int EmailCP3 { get; set; }

        [Display(Name = "Website")]
        public int Website { get; set; }

        [Display(Name = "Cataloge")]
        public int Cataloge { get; set; }

    }
}
