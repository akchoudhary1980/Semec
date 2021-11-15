using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class EmdFollowTransModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmdFollowTransID { get; set; }

        public int EmdCreateID { get; set; } // forgin key

        [Display(Name = "Follow Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? FollowDate { get; set; }

        public string FollowupType { get; set; } // Phone / Whatsup / Email / Visit
        public int EmployeeID { get; set; } // Follow by 

        [Display(Name = "Conversation")]
        [DataType(DataType.MultilineText)]
        public string Conversation { get; set; }

    }
}
