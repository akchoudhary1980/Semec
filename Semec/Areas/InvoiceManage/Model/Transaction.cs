using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semec.Areas.InvoiceManage.Model
{
    public class Transaction
    {
       
        public int SerNo { get; set; }
        public int ItemID { get; set; }       
        public string ItemName { get; set; }
        public string HSNCode { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public double GSTSlab { get; set; }
        public string GSTAmount { get; set; }
        
        public Transaction(int SerNo, int ItemID, string ItemName, string HSNCode, double Quantity, string Unit, string Rate, string Amount, double GSTSlab,string GSTAmount)
        {
            this.SerNo = SerNo;
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.HSNCode = HSNCode;
            this.Quantity = Quantity;
            this.Unit = Unit;
            this.Rate = Rate;
            this.Amount = Amount;
            this.GSTSlab = GSTSlab;
            this.GSTAmount = GSTAmount;
        }
    }
    
}