using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class TOrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TOrderID { get; set; }     // Inc  
        public int CustomerID { get; set; } // Customer ID       
        public string OrderNo { get; set; } // Order No         
        public string Status { get; set; } // T
    }
}
