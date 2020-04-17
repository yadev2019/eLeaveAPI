using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class vw_baland
    {
        public int userId { get; set; }
        public string fullName { get; set; }
        public double Holiday { get; set; }
        public double Sick { get; set; }
        public double Personal { get; set; }
        public string Email  { get; set; }
        public string Provider_Id { get; set; }
        public string Img { get; set; }
        public bool? isActive { get; set; }
        public Nullable<DateTime> Created_at { get; set; }
        public Nullable<DateTime> Updated_at { get; set; }

    }
}
