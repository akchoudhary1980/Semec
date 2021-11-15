using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class ProfessionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfessionID { get; set; }

        [Required(ErrorMessage = "Please Enter Profession Name")]
        [Display(Name = "Profession Name")]
        public string ProfessionName { get; set; } //Nama         
    }
}
