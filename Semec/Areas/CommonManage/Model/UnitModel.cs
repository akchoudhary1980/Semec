using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class UnitModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitID { get; set; }
        [Required(ErrorMessage = "Please Enter Unit Name")]
        [Display(Name = "Unit Name")]
        public string UnitName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }        
    }
}
