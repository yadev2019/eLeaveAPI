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
    public class ReferController : ControllerBase
    {
        readonly DBContext _context;
        public ReferController(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;// = new DBContext();
        // GET: api/Refer
        [HttpGet]
        public IEnumerable<Refer> Get()
        {
            return _context.Refers.ToList();
        }

        // POST: api/Refer
        [HttpPost]
        public void Post(Refer refer)
        {
            Refer result = _context.Refers.FirstOrDefault(p => p.refCode == refer.refCode && p.refName == refer.refName);
            if (result == null)
            {
                _context.Refers.Add(refer);
                _context.SaveChanges();
            }
        }

    }
}
