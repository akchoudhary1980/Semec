using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class ColorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ColorID { get; set; }
        [Required(ErrorMessage = "Please Enter Color Name")]
        [Display(Name = "Color Name")]
        public string ColorName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }      
    }
}
