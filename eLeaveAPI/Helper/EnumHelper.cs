using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eLeaveAPI.Helper
{
    public class EnumHelper
    {
        public enum Refer
        {
            Hiliday = 1,
            Personal = 2,
            Sick = 3,
        }
        public enum Status
        { 
            Request = 0,
            Approve = 1,
            Reject = 2,
            Cancel = 3,
        }
        public enum EventType
        {
            [Display(Name = "Morning")]
            Morning,
            [Display(Name = "Afternoon")]
            Afternoon,
            [Display(Name = "Full Day")]
            Fullday

        }
    }
}
