using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class VenderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VenderID { get; set; }

        [Required(ErrorMessage = "Please Enter Vender Name")]
        [Display(Name = "Vender Name")]
        public string VenderName { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Mobile")]
        [Display(Name = "Mobile")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 digit")]
        public string Mobile { get; set; }

        [Display(Name = "WhatsApp")]
        [StringLength(10)]
        public string Whatsup { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "GST No")]
        public string GSTNo { get; set; }        
    }
}
