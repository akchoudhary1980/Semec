using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class SliderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SliderID { get; set; }

        [Required(ErrorMessage = "Please Enter Slider Title")]
        [Display(Name = "Slider Title")]
        public string SliderTitle { get; set; }
        
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

       
        [Display(Name = "Display Status")]
        public bool IsDisplay { get; set; }

        
        [Display(Name = "Picture")]
        public string Picture { get; set; }
    }
}
