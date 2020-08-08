using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMP.DataAccessLayer
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Status { get; set; }
        public string Task { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime FinishDate { get; set; }

        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
