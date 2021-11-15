using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class TestimonialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int TestimonialID { get; set; }

        [Required(ErrorMessage = "Please Enter Testimonial Title")]
        [Display(Name = "Testimonial Title")]
        public string Title { get; set; }

        [Display(Name = "Testimonial Quote")]
        [DataType(DataType.MultilineText)]
        public string Testimonial { get; set; }

        [Display(Name = "Quote By")]       
        public string QuoteBy { get; set; }
        public string Picture { get; set; }
    }
}
