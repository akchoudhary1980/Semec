using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceID { get; set; }
        [Required (ErrorMessage ="Please Enter Service Name")]
        [Display (Name ="Service Name")]
        public string ServiceName { get; set; }


        [Display(Name = "Service Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Service Code")]
        public string Service { get; set; }

        [Display(Name = "SAC")]
        public string SAC { get; set; }

        [Display(Name = "Service Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Service Group")]
        public int GroupID { get; set; }
                

        [Display(Name = "Service Unit")]
        public int UnitID { get; set; }


        [Display(Name = "GST Slab")]
        public int GSTSlabID { get; set; }

        [Display(Name = "Charge")]
        public double Charge { get; set; }

        [Display(Name = "Service Charge")]
        public double ServiceCharge { get; set; }

        [Display(Name = "Is GST Inclusive ?")]
        public bool GSTInclusive { get; set; }

    }
}
