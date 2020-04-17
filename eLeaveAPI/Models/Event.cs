using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int Topic { get; set; }
        public Nullable<DateTime> startDate { get; set; }
        public Nullable<DateTime> endDate { get; set; }
        public  string Reason { get; set; }
        public int statusId { get; set; }

        public string ImgPath { get; set; }
        public double Amount { get; set; }
        public string Eventtype { get; set; }
        public Nullable<DateTime> Created_at { get; set; }
        public Nullable<DateTime> Updated_at { get; set; }
    }
}
