using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class RoomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }
        [Required(ErrorMessage ="Please Enter Room Name")]
        [Display(Name ="Room Name")]
        public string RoomName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }       
    }
}
