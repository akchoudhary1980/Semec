using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class OnlineProductPackingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductPackingID { get; set; }

        [Display(Name = "Product Size")]
        public string ProductSize { get; set; }

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
        public int ProductID { get; set; }
    }
}
