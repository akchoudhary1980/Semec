using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class DealInModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealInID { get; set; }

        [Display(Name = "Product Name")]
        public int Product { get; set; }
        public int DealersID { get; set; }

    }
}
