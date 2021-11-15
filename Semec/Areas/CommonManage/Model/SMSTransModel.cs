using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class SMSTransModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SMSTransID { get; set; }
        public DateTime SMSDate { get; set; }
        public TimeSpan SMSTime { get; set; }
        public int CustomerID { get; set; } // forgin Key 
        public string Mobile { get; set; }
        public string SMSMessage { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
        public string DeviceIP { get; set; }
        public int SMSCount { get; set; }  // D        
        public string PropertyType { get; set; }  // D  
        public int PropertyID { get; set; }  // D  
    }
}
