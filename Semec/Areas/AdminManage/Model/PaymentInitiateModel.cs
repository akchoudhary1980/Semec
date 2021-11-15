using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semec.Areas.AdminManage.Model
{
    public class PaymentInitiateModel
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public double Amount { get; set; }
    }
}