using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class OnlineProductArrangeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductArrangeID { get; set; }
        public int ProductID { get; set; }
        public int OrderNo { get; set; }
    }
}
