using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class BinModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BinID { get; set; }
        [Required(ErrorMessage = "Please Enter Bin Name")]
        [Display(Name = "Bin Name")]
        public string BinName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }       
    }
}
