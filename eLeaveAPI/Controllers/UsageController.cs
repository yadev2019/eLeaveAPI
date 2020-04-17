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
    public class UsageController : ControllerBase
    {
        readonly DBContext _context;
        public UsageController(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;// = new DBContext();
        // GET: api/Usage
        [HttpGet]
        public IEnumerable<vw_baland> Get()
        {
            return _context.vw_balands.ToList();
        }

        // GET: api/Usage/5
        [HttpGet("{id}", Name = "Get3")]
        public string Get3(int id)
        {
            return "value";
        }

        // POST: api/Usage
        [HttpPost]
        public void Post(Usage usage)
        {
            Usage result = _context.Usages.FirstOrDefault(p => p.userId == usage.userId);
            if (result == null)
            {
                _context.Add(usage);
                _context.SaveChanges();
            }
        }
    }
}
