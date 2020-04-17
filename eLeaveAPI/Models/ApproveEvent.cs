using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class ApproveEvent
    {
        public int? eId { get; set; }
        public int? userId { get; set; }
        public int? statusCode { get; set; }
        public int? Topic { get; set; }
    }
}
