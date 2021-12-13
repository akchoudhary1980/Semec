using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.TenderSearchManage.Model
{
    public class DepartmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        
    }
}
