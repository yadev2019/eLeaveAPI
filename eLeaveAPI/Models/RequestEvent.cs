using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class RequestEvent
    {
        public int userId { get; set; }
        public int topic { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
        public string eventtype { get; set; }
    }
}
