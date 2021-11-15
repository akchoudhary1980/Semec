using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class EmailTransModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmailTransID { get; set; }
        public DateTime EmailDate { get; set; }
        public TimeSpan EmailTime { get; set; }
        public int CustomerID { get; set; } // forgin Key 
        public string EmailTo { get; set; } // To 
        public string EmailTitle { get; set; } 
        public string EmailMessage { get; set; }
        public string AttachedFile { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
        public string DeviceIP { get; set; }
        public string PropertyType { get; set; }  // D  
        public int PropertyID { get; set; }  // D  
    }
}
