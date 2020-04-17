
using eLeaveAPI.Helper;
using eLeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Controllers
{
    public class Services
    {
        readonly DBContext _context;
        public Services(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;//  = new DBContext();
        public double getCountDateLeave(DateTime? StartDate, DateTime? EndDate,string Eventtype)
        {


            DateTime start = (DateTime)StartDate;
            DateTime end = (DateTime)EndDate;
            double result = (end - start).Days + 1;

            if (Eventtype != EnumHelper.EventType.Fullday.ToString())
            {
                result = 0.5;
            }
            return result;
        }
        public double ChekLeaveByUserId(int userId, int topic)
        {
            double total = 0;
            var result = _context.Usages.FirstOrDefault(o => o.userId == userId);
            #region
            if (result != null)
            {
                if (topic == 1)
                {
                    total = result.Holiday;
                }
                else if (topic == 3)
                {
                    total = result.Sick;
                }
                else if (topic == 2)
                {
                    total = result.Personal;
                }
            }
            #endregion
            return total;
        }

        public bool ApproveLeaveByUserId(int eventId, int userId)
        {
            bool flag = false;
            var result = _context.Events.FirstOrDefault(o => o.Id == eventId && o.userId == userId);
            #region
            if (result != null)
            {
                Event ev = new Event();
                ev.Id = result.Id;
                ev.statusId = (int)EnumHelper.Status.Approve;

                _context.Update(ev);
                _context.SaveChanges();
            }
            #endregion
            return flag;
        }
    }
}
