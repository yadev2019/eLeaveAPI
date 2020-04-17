using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Provider { get; set; }
        public string Provider_Id { get; set; }
        public string Img { get; set; }
        public string remember_token { get; set; }
        public Boolean? isActive { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    }
}
