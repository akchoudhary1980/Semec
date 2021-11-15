using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class CategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }         
    }
}
