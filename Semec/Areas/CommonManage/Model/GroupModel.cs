using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class GroupModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }
        [Required(ErrorMessage = "Please Enter Group Name")]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }        
    }
}
