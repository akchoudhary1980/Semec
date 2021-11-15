using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.InvoiceManage.Model
{
    public class PurchaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseID { get; set; }

        [Display(Name ="Purchase No")]
        public int SerialNo { get; set; }

        [Display(Name = "Purchase State")]
        public bool PurchaseState { get; set; }

        [Display(Name = "Purchase Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Vender Name")]
        public int VenderID { get; set; }

        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Invoice Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Transporter Name")]
        public string TransportName { get; set; }

        [Display(Name = "DOC No")]
        public string DocNo { get; set; }

        [Display(Name = "Material Center")]
        public int MaterialCenterID { get; set; }

        [Display(Name = "GodownID")]
        public int GodownID { get; set; }

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        public double PurchaseValue { get; set; }
        public double PurchaseGST { get; set; }
        public double PurchaseTotal { get; set; }

        public double DiscountValue { get; set; }
        public double DiscountPercent { get; set; }
        public double Discount { get; set; }        
    }
}
