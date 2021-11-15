using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class EmailTempleteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmailTempleteID { get; set; }

        [Required(ErrorMessage = "Please Enter Email Title")]
        [Display(Name = "Email Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Email Heading")]
        [Display(Name = "Email Heading")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Please Enter SMS Message")]
        [Display(Name = "Email Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}
