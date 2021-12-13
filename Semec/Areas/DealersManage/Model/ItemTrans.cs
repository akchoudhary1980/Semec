using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semec.Areas.DealersManage.Model
{
    public class ItemTrans
    {       
        public int SerNo { get; set; }
        public int ItemID { get; set; }       
        public string ItemName { get; set; }
        public ItemTrans(int SerNo, int ItemID, string ItemName)
        {
            this.SerNo = SerNo;
            this.ItemID = ItemID;
            this.ItemName = ItemName;
        }
    }
    
}