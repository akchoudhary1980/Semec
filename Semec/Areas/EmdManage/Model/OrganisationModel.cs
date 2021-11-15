using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.EmdManage.Model
{
    public class OrganisationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganisationID { get; set; }

        [Required(ErrorMessage = "Please Enter Organisation Name")]
        [Display(Name = "Organisation Name*")]
        public string OrganisationName { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }     


        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }        

        [Display(Name = "GST No")]
        public string GSTNo { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }


        // Contact Person 
        [Required(ErrorMessage = "Please Enter Contact Name")]
        [Display(Name = "Contact Person *")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person's Mobile")]
        [Display(Name = "Mobile *")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 digit")]
        public string Mobile { get; set; }

        [Display(Name = "WhatsApp")]
        [StringLength(10)]
        public string Whatsup { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }        
    }
}
