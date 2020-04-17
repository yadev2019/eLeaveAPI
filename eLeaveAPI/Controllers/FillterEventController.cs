using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLeaveAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillterEventController : ControllerBase
    {
        readonly DBContext _context;
        public FillterEventController(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;// = new DBContext();
        // GET: api/FillterEvent
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FillterEvent/5
        [HttpGet("{id}", Name = "Get1111")]
        public string Get1111(int id)
        {
            return "value";
        }

        // POST: api/FillterEvent
        [HttpPost]
        public IEnumerable<vw_event> Post(FilterEvent fillter)
        {
            //List<string> statusList = fillter.iStatus.Select(y => y.statusName).ToList();
            IEnumerable<vw_event> result = _context.vw_events.ToList();
            if (fillter.userId == null)
            {             
                result = result.Where(o => fillter.iStatus.Contains((int)o.statusCode));
            }
            else
            {
                //user
                Nullable<DateTime> datenow = DateTime.Now;
                result = result.Where(o => o.userId == fillter.userId && o.startDate >= datenow && fillter.iStatus.Contains((int)o.statusCode));
            }
            return result;
        }
    }
}
