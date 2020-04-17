using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLeaveAPI.Helper;
using eLeaveAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eLeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestEventController : ControllerBase
    {
        readonly DBContext _context;

        public RequestEventController(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;// = new DBContext();
        //private readonly DBQuery _db = new DBQuery();
        // GET: api/Event
        [HttpGet]
        public IEnumerable<vw_event> GetEvent()
        {
            //var result = _context.Query<vw_event>().ToList();
            var result = _context.vw_events.ToList();
            return result;
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "GetEvent")]
        public vw_event GetById(int id)
        {
            var result = _context.vw_events.FirstOrDefault(o => o.Id == id);
            return result;
        }

        // POST: api/Event
        [HttpPost]
        public IActionResult Post(RequestEvent req)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Services sv = new Services(_context);
                    if (req != null)
                    {

                        var result = _context.Events.FirstOrDefault(o => o.userId == req.userId && o.startDate == req.startDate);
                        if (result != null)
                        {
                            return Ok(new { message = "คำขออยู่ระหว่างพิจารณา", success = false });
                        }


                        
                        double total_leave_by_group = sv.ChekLeaveByUserId(req.userId, req.topic);
                        double total_amount_request = sv.getCountDateLeave(req.startDate, req.endDate, req.eventtype);
                        if (total_leave_by_group == 0)
                        {
                            return Ok(new { message = "จำนวนวันลาไม่มีแล้ว", success = false });
                        }

                        if (total_amount_request > total_leave_by_group)
                        {
                            string msg = $"วันลาคงเหลือ {total_leave_by_group}. ไม่พอกับจำนวนที่ขอลา";
                            return Ok(new { message = msg , success = false });
                        }

                        Event md = new Event();
                        md.userId = req.userId;
                        md.Topic = req.topic;
                        md.startDate = req.startDate;
                        md.endDate = req.endDate;
                        md.statusId = (int)EnumHelper.Status.Request;
                        md.Reason = req.reason;
                        md.Amount = total_amount_request;
                        md.Eventtype = req.eventtype;
                        md.Created_at = DateTime.Now;

                        _context.Events.Add(md);
                        _context.SaveChanges();
                        transaction.Commit();


                        return Ok(new { message = "สำเร็จ", success = true });
                    }
                    return Ok();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Ok(new { message = ex.ToString(), success = false });

                }
            }
        }


    }
}
