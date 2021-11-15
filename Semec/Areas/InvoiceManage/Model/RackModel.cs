using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class RackModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RackID { get; set; }
        [Required(ErrorMessage ="Please Enter Rack Name")]
        [Display(Name ="Rack Name")]
        public string RackName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }        
    }
}
