using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class OnlinePaymentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }
        public string PaymentMode { get; set; } // Cash // Cheque // RTGS / NEFT // Electronic Media        
        public DateTime RecieptDate { get; set; }
        public double Amount { get; set; }
        public string yPaymentGetwayName { get; set; }
        public string GetwayPaymentID { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderID { get; set; }
        public string TransactionID { get; set; }
        public int CustomerID { get; set; } //cutomer  ID  
        public int SaleID { get; set; } //Sale ID   
    }
}
