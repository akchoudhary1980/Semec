using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.AdminManage.Model
{
    public class VisiterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VisiterID { get; set; }
        public string SessionID { get; set; }

        public DateTime? VisitDate { get; set; }
        public TimeSpan? StartTime  { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }

        public string DeviceName { get; set; }
        public string ComputerName { get; set; }
        public string ComputerIP { get; set; }
        public string Location { get; set; }

        public bool IsRead { get; set; }
    }
}
