using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class PurchaseRetrunTransModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int PurchaseReturnTransID { get; set; }       
        public int ProductSerNo { get; set; }
        public int ProductID { get; set; } // Service ID
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double GSTSlab { get; set; }
        public double GSTAmount { get; set; }
        public string ItemType { get; set; }
        public int PurchaseRetrunID { get; set; }

    }
}
