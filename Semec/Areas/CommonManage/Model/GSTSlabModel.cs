using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class GSTSlabModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GSTSlabID { get; set; }

        [Required(ErrorMessage = "Please Enter GST Slab Name")]
        [Display(Name = "GST Slab Name")]
        public string GSTSlabName { get; set; }

        [Required(ErrorMessage = "Please Enter GST Slab Percent")]
        [Display(Name = "GST Slab Percent")]
        public double PercentValue { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }        
    }
}
