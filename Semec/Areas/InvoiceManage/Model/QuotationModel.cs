using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class QuotationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuotationID { get; set; }

        [Display(Name = "Sale No")]
        public int SerialNo { get; set; }

        [Display(Name = "Ref No")]
        public string RefNo { get; set; }

        [Display(Name = "Quotation State")]
        public bool QuotationState { get; set; }

        [Display(Name = "Quotation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime QuotationDate { get; set; }

        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; }
        public double QuotationValue { get; set; }
        public double QuotationGST { get; set; }
        public double QuotationTotal { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercent { get; set; }
        public double Discount { get; set; }

        [Display(Name = "Expacted Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ExpactedDate { get; set; }

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        
    }
}
