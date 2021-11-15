using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class ProposalModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProposalID { get; set; }

        [Display(Name = "Proposal No")]
        public int SerialNo { get; set; }


        [Display(Name = "Proposal Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]       
        public DateTime? ProposalDate { get; set; }

        [Display(Name = "Reminder Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ReminderDate { get; set; }


        [Display(Name = "Project Name")]       
        public string ProjectName { get; set; }

        [Display(Name = "Office Name")]
        public string OfficeName { get; set; }


        [Display(Name = "CustomerName Name")]
        public int CustomerID { get; set; }
        

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        public double ProposalValue { get; set; }
        public double ProposalGST { get; set; }
        public double ProposalTotal { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercent { get; set; }
        public double Discount { get; set; }
               
    }
}
