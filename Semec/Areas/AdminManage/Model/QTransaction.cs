using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semec.Areas.AdminManage.Model
{
    public class QTransaction
    {      
        public int SerNo { get; set; }
        public int ItemID { get; set; }       
        public string ItemName { get; set; }       
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public double GSTSlab { get; set; }
        public string GSTAmount { get; set; }
        public string TotalAmount { get; set; }
        public string TotalGST { get; set; }
        public string GrandTotal { get; set; }
        public QTransaction(int SerNo, int ItemID, string ItemName, double Quantity, string Unit, string Rate, string Amount, double GSTSlab,string GSTAmount, string TotalAmount, string TotalGST, string GrandTotal)
        {
            this.SerNo = SerNo;
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.Quantity = Quantity;
            this.Unit = Unit;
            this.Rate = Rate;
            this.Amount = Amount;
            this.GSTSlab = GSTSlab;
            this.GSTAmount = GSTAmount;

            this.TotalAmount = TotalAmount;
            this.TotalGST = TotalGST;
            this.GrandTotal = GrandTotal;
        }
    }
    
}