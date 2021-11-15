using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class SalesReturnModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalesReturnID { get; set; }

        [Display(Name = "Sale No")]
        public int SerialNo { get; set; }

        [Display(Name = "Ref No")]
        public string RefNo { get; set; }

        [Display(Name = "Sale Return Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime RetrunDate { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerID { get; set; } // key 
        public double SaleValue { get; set; }
        public double SaleGST { get; set; }
        public double SaleTotal { get; set; }

        public double DiscountValue { get; set; }
        public double DiscountPercent { get; set; }
        public double Discount { get; set; }

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }      
        
    }
}
