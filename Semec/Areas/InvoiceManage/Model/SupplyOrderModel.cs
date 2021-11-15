using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class SupplyOrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplyOrderID { get; set; }

        [Display(Name ="Supply Order No")]
        public int SerialNo { get; set; }

        [Display(Name = "Ref No")]
        public string RefNo { get; set; }

        [Display(Name = "Supply Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]       
        public DateTime? SupplyOrderDate { get; set; }

        [Display(Name = "Due Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DueDate { get; set; }


        [Display(Name = "Customer Name")]
        public string CustomerID { get; set; }
                

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        public double SupplyOrderValue { get; set; }
        public double SupplyOrderGST { get; set; }
        public double SupplyOrderTotal { get; set; }

        public double DiscountValue { get; set; }
        public double DiscountPercent { get; set; }
        public double Discount { get; set; }

        public double Progress { get; set; }        
    }
}
