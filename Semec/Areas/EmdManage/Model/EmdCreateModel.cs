using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class EMDCreatModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmdCreateID { get; set; }

        //Documents Type
        public int EMDDocumentsTypeID { get; set; } // DD  

        [Display(Name = "Create Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? CreateDate { get; set; }

        public bool IsRefundable { get; set; } // Yes / No
        public int BankID { get; set; } // Create from 
        public int OrganisationID { get; set; } // Create In Favour of   


        public string EmdFor { get; set; } // Tender Cost / EMD / Performance

        public string DocumentNo { get; set; }
        public double EmdAmount { get; set; }
        public double EmdCharges { get; set; }

        public string DocumentStatus { get; set; } // Create / Issue / Cancel / Reciept // Very IMP

        public string SoftCopy { get; set; } // File Upload
        public string XeroxLocation { get; set; } // File Location


        [Display(Name = "From Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
    }
}
