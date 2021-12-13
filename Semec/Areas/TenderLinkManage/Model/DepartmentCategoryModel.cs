using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.TenderLinkManage.Model
{
    public class DepartmentCategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentCategoryID { get; set; }
        [Required(ErrorMessage = "Please Enter Department Category Name")]

        [Display(Name = "Department Category Name")]

        public string DepartmentCategoryName { get; set; }
        
    }
}
