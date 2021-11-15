using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Display(Name = "HSN Code")]
        public string HSNCode { get; set; }


        [Display(Name = "Product Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Product Group")]
        public int GroupID { get; set; }

        [Display(Name = "Product Brand")]
        public int BrandID { get; set; }

        [Display(Name = "Product Color")]
        public int ColorID { get; set; }

        [Display(Name = "Product Unit")]
        public int UnitID { get; set; }

        [Display(Name = "GST Slab")]
        public int GSTSlabID { get; set; }

        [Display(Name = "MRP Rate")]
        public double MRPRate { get; set; }

        [Display(Name = "Sale Rate")]
        public double Rate { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Is GST Inclusive ?")]
        public bool GSTInclusive { get; set; }

        [Display(Name = "Product Picture")]
        public string Picture { get; set; }

        // Location 
        [Display(Name = "Material Center")]
        public int MaterialCenterID { get; set; }
        [Display(Name = "Godown")]
        public int GodownID { get; set; }
        [Display(Name = "Room No")]
        public int RoomNoID { get; set; }
        [Display(Name = "Rack No")]
        public int RackNoID { get; set; }
        [Display(Name = "Self No")]
        public int SelfNoID { get; set; }
        [Display(Name = "Bin No")]
        public int BinNoID { get; set; }
        public string Location { get; set; }
        // Stock
        [Display(Name = "Min Level")]
        public double StockMinimumLevel { get; set; }
        [Display(Name = "Max Level")]
        public double StockMaximumLevel { get; set; }

        [Display(Name = "Opening Stock")]
        public double OpeningStock { get; set; }
    }
}
