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
    public class StatusController : ControllerBase
    {
        readonly DBContext _context;
        public StatusController(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;// = new DBContext();
        // GET: api/Status
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _context.Status.ToList();
        }

        // POST: api/Status
        [HttpPost]
        public void Post(Status status)
        {
            Status result = _context.Status.Where(o => o.statusName == status.statusName).FirstOrDefault();
            if (result == null)
            {
                _context.Status.Add(status);
                _context.SaveChanges();
            }
        }
    }
}
