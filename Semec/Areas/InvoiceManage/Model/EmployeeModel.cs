using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Nic Name")]
        public string NicName { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Mobile")]
        [Display(Name = "Mobile")]
        [StringLength(10)]
        public string Mobile { get; set; }


        [Display(Name = "WhatsApp")]
        [StringLength(10)]
        public string Whatup { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateofBirth { get; set; }

        [Display(Name = "Date of Joining")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateofJoining { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Salary")]
        [Display(Name = "Salary")]
        public double? Salary { get; set; }

        [Display(Name = "Maximum Qualification")]
        public string Qualification { get; set; } // Max Qualification

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Please Select Designation Name")]
        [Display(Name = "Designation")]
        public int DesignationID { get; set; }   

    }
}
