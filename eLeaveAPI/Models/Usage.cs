using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class Usage
    {
        
        public int Id { get; set; }
        public int userId { get; set; }
        public double Holiday { get; set; }
        public double Sick { get; set; }
        public double Personal { get; set; }
        public Nullable<DateTime> Created_at { get; set; }
        public Nullable<DateTime> Updated_at { get; set; }

    }
}
