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
    public class BalandController : ControllerBase
    {
        readonly DBContext _context;
        public BalandController(DBContext context)
        {
            _context = context;
        }
        // GET: api/Baland
        [HttpGet]
        public IEnumerable<vw_baland> Get()
        {
            return _context.vw_balands.ToList();
        }

        // GET: api/Baland/5
        [HttpGet("{id}", Name = "Baland")]
        public vw_baland Baland(int id)
        {
            return _context.vw_balands.Where(o => o.userId == id).FirstOrDefault();
        }

        // POST: api/Baland
        [HttpPost]
        public IActionResult  Post()
        {
            try
            {
                List<Usage> result = _context.Usages.ToList();           
                foreach (var i in result)
                {
                    var md = _context.Usages.FirstOrDefault(o => o.userId == i.userId);
                    //Usage md = new Usage();
                    //md.Id = i.Id;
                    //md.userId = i.userId;
                    md.Sick = 5;
                    md.Personal = 5;
                    md.Holiday = 5;
                    //md.Created_at = i.Created_at;
                    md.Updated_at = DateTime.Now;
                    _context.Usages.Update(md);                    
                    //_context.Usages.Update(md);
                }
                _context.SaveChanges();
                return Ok();
            }
            catch {
                return BadRequest();
            }

        }

    }
}
