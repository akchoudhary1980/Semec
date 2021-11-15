using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class OnlineSalesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalesID { get; set; }

        [Display(Name = "Sale No")]
        public string SerialNo { get; set; }

        [Display(Name = "Order No")]
        public string OrderNo { get; set; }

        [Display(Name = "Sale Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime SalesDate { get; set; }           
        

        [Display(Name = "CustomerName Name")]
        public int CustomerID { get; set; } // key 

        public double SaleValue { get; set; }
        public double DeliveryValue { get; set; }
        public double SaleGST { get; set; }       
        public double SaleTotal { get; set; }

        public string SaleMode { get; set; } // Online // Offline
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public bool SaleState { get; set; }
    }
}
