using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class TenderLinkModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TenderLinkID { get; set; }

        [Display(Name = "Bank Name")]
        public int BankName { get; set; }

        [Display(Name = "Branch Name")]
        public int Branch { get; set; }

        [Display(Name = "IFSC Code")]
        public int IFSCCode { get; set; }

        [Display(Name = "City Name")]
        public int CityName { get; set; }
    }
}
