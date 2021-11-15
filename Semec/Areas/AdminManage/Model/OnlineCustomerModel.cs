using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class OnlineCustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }


        [Display(Name = "Delivery Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Display(Name = "Address Type")]
        public string AddressType { get; set; }


        [Display(Name = "Delivery Time")]
        public string DeliveryTime { get; set; }


        [Display(Name = "Area")]
        public string Area { get; set; }


        [Display(Name = "Pin Code")]
        public string Pin { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }


        [Display(Name = "Country")]
        public string Country { get; set; }


        [Required(ErrorMessage = "Please Enter Customer's Mobile")] // as user ID
        [Display(Name = "Mobile")]       
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 digit")]
        public string Mobile { get; set; }


        [Display(Name = "Alternet Mobile")]
        [StringLength(10)]
        public string AlternetMobile { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")] // as user id
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")] // as password
        [Display(Name = "Password")]        
        public string Password { get; set; }


        [Display(Name = "Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Unniversary")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Unniversary { get; set; }


        [Required(ErrorMessage = "Please Select Customer Profession")]
        [Display(Name = "Profession")]
        public int ProfessionID { get; set; } // Unkown Govt. / Prive / Buss  Controller    

        [Display(Name = "Profile Complete")]       
        public double ProfileComplete { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }
    }
}
