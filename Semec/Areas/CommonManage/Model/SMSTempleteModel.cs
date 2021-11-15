using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class SMSTempleteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SMSTempleteID { get; set; }

        [Required(ErrorMessage = "Please Enter SMS Title")]
        [Display(Name = "SMS Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter SMS Message")]
        [Display(Name = "SMS Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }        

    }
}
