using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Type")]
        public string CustomerType { get; set; }


        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }


        [Required(ErrorMessage = "Please Enter Customer's Mobile")]
        [Display(Name = "Mobile")]       
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 digit")]
        public string Mobile { get; set; }


        [Display(Name = "WhatsApp")]
        [StringLength(10)]
        public string Whatsup { get; set; }

        [Display(Name = "Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Anniversary")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Anniversary { get; set; }
               
        [Display(Name = "Email")]       
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Select Customer Profession")]
        [Display(Name = "Profession")]
        public int ProfessionID { get; set; } // Govt. / Prive / Buss  Controller   

        [Display(Name = "GST No")]
        public string GSTNo { get; set; }
       
    }
}
