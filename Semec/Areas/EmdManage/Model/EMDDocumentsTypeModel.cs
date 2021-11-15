using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class EMDDocumentsTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMDDocumentsTypeID { get; set; }

        [Display(Name = "Documents Type")]
        public int DocumentsType { get; set; }

        [Display(Name = "Remark")]
        public int Remark { get; set; }
    }
}
