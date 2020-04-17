using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class Refer
    {
        public int Id { get; set; }
        public int refCode { get; set; }
        public string refGroup { get; set; }
        public string refName { get; set; }
        public Nullable<DateTime> Created_at { get; set; }
        public Nullable<DateTime> Updated_at { get; set; }
    }
}
