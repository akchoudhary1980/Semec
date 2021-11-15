using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class SelfModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SelfID { get; set; }
        [Required(ErrorMessage ="Please Enter Self Name")]
        [Display(Name ="Self Name")]
        public string SelfName { get; set; }
        [Display(Name ="Self Name")]
        public string Remark { get; set; }       
    }
}
