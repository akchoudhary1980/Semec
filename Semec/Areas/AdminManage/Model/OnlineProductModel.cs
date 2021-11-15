using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class OnlineProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please Enter Product Code")]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Display(Name = "HSN Code")]
        public string HSNCode { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Full Description")]
        [DataType(DataType.MultilineText)]
        public string FullDescription { get; set; }

        [Display(Name = "Product Brand")]
        public int BrandID { get; set; }

        [Display(Name = "Product Category")]
        public int CategoryID { get; set; }        

        [Display(Name = "Product Unit")]
        public int UnitID { get; set; }

        [Display(Name = "GST Slab")]
        public int GSTSlabID { get; set; }

        [Display(Name = "Is GST Inclusive ?")]
        public bool GSTInclusive { get; set; }


        [Display(Name = "MRP Rate")]
        public double MRP { get; set; }

        [Display(Name = "Sale Rate")]
        public double Rate { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Delivery Charge")]
        public double DeliveryCharge { get; set; }

        [Display(Name = "Front Page ?")]
        public string DisplayOn { get; set; }

        [Display(Name = "Stock Qty")]
        public double StockQty { get; set; }

        [Display(Name = "Alert Stock Qty")]
        public double AlertStockQty { get; set; }

        [Display(Name = "Is New ?")]
        public bool IsNew { get; set; }

        [Display(Name = "Is Seal ?")]
        public bool IsSeal { get; set; }


        [Display(Name = "View")]
        public int View { get; set; }

        [Display(Name = "Like")]
        public int Like { get; set; }

        [Display(Name = "Dislike")]
        public int DisLike { get; set; }

        [Display(Name = "Product Rating")]
        public int Rating { get; set; }


        [Display(Name = "Main Picture")]
        public string Picture { get; set; }


        [Display(Name = "Product Picture 1")]
        public string Picture1 { get; set; }

        [Display(Name = "Product Picture 2")]
        public string Picture2 { get; set; }

        [Display(Name = "Product Picture 3")]
        public string Picture3 { get; set; }

        [Display(Name = "Product Picture 4")]
        public string Picture4 { get; set; }


    }
}
