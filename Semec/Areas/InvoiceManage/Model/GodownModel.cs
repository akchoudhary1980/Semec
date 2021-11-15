using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class GodownModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GodownID { get; set; }
        [Required(ErrorMessage = "Please Enter Godown Name")]
        [Display(Name = "Godown Name")]
        public string GodownName { get; set; }
        [Display (Name ="Remark")]
        public string Remark { get; set; }       
    }
}
