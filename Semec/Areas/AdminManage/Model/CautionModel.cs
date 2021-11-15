using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class CautionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CautionID { get; set; }

        [Required(ErrorMessage = "Please Enter Running Message")]
        [Display(Name = "Running Message")]
        public string CautionMessage { get; set; }
    }
}
