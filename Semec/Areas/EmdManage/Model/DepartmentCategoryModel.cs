using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class DepartmentCategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentCategoryID { get; set; }

        [Display(Name = "Department Category")]

        public int DepartmentCategory { get; set; }
        
    }
}
