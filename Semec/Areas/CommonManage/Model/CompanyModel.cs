using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class CompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }
        
        [Display(Name = "City")]
        public string CompanyCity { get; set; }

        [Display(Name = "State")]
        public string CompanyState { get; set; }

        [Display(Name = "Onwer Name")]
        public string OnwerName { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } // from Drop Down 
        
        [Display(Name = "Mobile")]
        public string CompanyMobile { get; set; }
        
        [Display(Name = "Whatsup")]
        public string CompanyWhatsup { get; set; }

        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Registration Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateofRegistration { get; set; }

        [Display(Name = "GST No")]
        public string GST { get; set; } // Number 

        [Display(Name = "Invoice Prefix")]
        public string InvoicePrefix { get; set; }

        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; } // Control from here

        [Display(Name = "Quotation Number")]
        public int QuotationNumber { get; set; } // Control from here

        [Display(Name = "Purchase Number")]

        public int PurchaseNumber { get; set; } // Control from here


        [Display(Name = "Company Picture")]
        public string CompanyPicture { get; set; } // Main Logo       

        [Display(Name = "Seal Picture")]
        public string SealPicture { get; set; } // Seal  

        // Banking Details 
        [Display(Name = "Beneficiary Name")]
        public string BeneficiaryName { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Account No")]
        public string AccountNumber { get; set; }

        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        [Display(Name = "IFSC Code")]
        public string AccountIFSCCode { get; set; }

        [Display(Name = "MICR Code")]
        public string AccountMICRCode { get; set; }

    }
}
