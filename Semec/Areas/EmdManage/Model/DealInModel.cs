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

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Item ID")]
        public int ItemID { get; set; }
        [Display(Name = "Dealer ID")]
        public int DealersID { get; set; }
        

    }
}
