using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class BrandModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandID { get; set; }
        [Required(ErrorMessage = "Please Enter Brand Name")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }         
    }
}
