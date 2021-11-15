using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semec.Areas.AdminManage.Model
{
    public class ShopTransaction
    {      
        public int SerNo { get; set; }
        public int ItemID { get; set; }       
        public string ItemName { get; set; }
        public string ItemShortDescription { get; set; }
        public string ItemPicture { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public double GSTSlab { get; set; }
        public string GSTAmount { get; set; }
        public string DeliveryCharge { get; set; }
        public string TotalAmount { get; set; }
        public string TotalGST { get; set; }
        public string GrandTotal { get; set; }
        public string DeliveryTotal { get; set; }
        // constructor
        public ShopTransaction(int SerNo, int ItemID, string ItemName, string ItemShortDescription, string ItemPicture, double Quantity, string Unit, string Rate, string Amount, double GSTSlab,string GSTAmount, string DeliveryCharge, string TotalAmount, string TotalGST, string GrandTotal,string DeliveryTotal)
        {
            this.SerNo = SerNo;
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.ItemShortDescription = ItemShortDescription;
            this.ItemPicture = ItemPicture;

            this.Quantity = Quantity;
            this.Unit = Unit;
            this.Rate = Rate;
            this.Amount = Amount;
            this.GSTSlab = GSTSlab;
            this.GSTAmount = GSTAmount;
            this.DeliveryCharge = DeliveryCharge;

            this.TotalAmount = TotalAmount;
            this.TotalGST = TotalGST;
            this.GrandTotal = GrandTotal;
            this.DeliveryTotal = DeliveryTotal;
        }
    }
    
}