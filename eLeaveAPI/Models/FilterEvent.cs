using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class FilterEvent
    {
        public int? userId { get; set; }
        public List<int> iStatus { get; set; }
        public bool? isActive { get; set; }
    }
    //public class StatusModel
    //{
    //    public string statusName { get; set; }
    //}

}
