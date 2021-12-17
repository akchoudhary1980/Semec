using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.TenderQuoteManage.Model
{
    public class DigitalSignatureModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DigitalSignatureID { get; set; }

        [Required(ErrorMessage = "Please Enter Digital Signature Name")]
        [Display(Name = "Digital Signature Name")]
        public string DigitalSignatureName { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }        
    }
}
