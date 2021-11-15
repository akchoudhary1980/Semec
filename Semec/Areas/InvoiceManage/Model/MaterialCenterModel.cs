using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class MaterialCenterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaterialCenterID { get; set; }
        [Required(ErrorMessage = "Please Enter Material Center Name")]
        [Display(Name = "Material Center Name")]
        public string MaterialCenterName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }       
    }
}
