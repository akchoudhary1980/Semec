using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class SalesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalesID { get; set; }

        [Display(Name = "Sale No")]
        public int SerialNo { get; set; }

        [Display(Name = "Ref No")]
        public string RefNo { get; set; }

        [Display(Name = "Sale State")]
        public bool SaleState { get; set; }

        [Display(Name = "Sale Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime SalesDate { get; set; }       
        public int AutoNoAuto { get; set; } // Virtual

        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; } // key 
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
