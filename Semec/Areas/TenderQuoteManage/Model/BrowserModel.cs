using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.TenderQuoteManage.Model
{
    public class BrowserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrowserID { get; set; }
        [Required(ErrorMessage = "Please Enter Browser Name")]
        [Display(Name = "Browser Name")]
        public string BrowserName { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }        
    }
}
