using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class ContactModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnquiryID { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Valid Mobile")]
        [Display(Name = "Mobile")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Enter Your Valid Mobile")]
        public string Mobile { get; set; }


        [Required(ErrorMessage = "Please Enter Your Valid Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your State Name")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Your City Name")]
        [Display(Name = "City")]
        public string City { get; set; }


        
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your Query")]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }        
        public DateTime? MessageDate { get; set; }
        public bool IsRead { get; set; }
        public string EnquiryStatus { get; set; } /// Open // Progress / Close
    }
}
