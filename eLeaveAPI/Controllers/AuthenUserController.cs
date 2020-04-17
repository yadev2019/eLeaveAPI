using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eLeaveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eLeaveAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenUserController : ControllerBase
    {
        readonly DBContext _context;
        public AuthenUserController(DBContext context)
        {
            _context = context;
        }
        //private readonly DBContext _context;// = new DBContext();
        // GET: api/AuthenUser
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // GET: api/AuthenUser/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<User>> GetById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var reuslt = await _context.Users.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
                if (reuslt == null)
                {
                    return NotFound();
                }
                return Ok(reuslt);

            }
            catch {
                return BadRequest();
            }

        }

        // POST: api/AuthenUser

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    User result = _context.Users.Where(o => o.Email == user.Email).FirstOrDefault();
                    if (result != null)
                    {


                        result.Updated_at = DateTime.Now;
                        _context.Users.Update(result);
                        await _context.SaveChangesAsync();                     
                        transaction.Commit();
                        return Ok(result);
                    }

                    else
                    {
                        user.Created_at = DateTime.Now;
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();
                        var getUserId = _context.Users.FirstOrDefault(o => o.Email == user.Email);
                        Usage us = new Usage();
                        us.userId = (int)getUserId.Id;
                        us.Holiday = 5;
                        us.Sick = 5;
                        us.Personal = 5;
                        us.Created_at = DateTime.Now;
                        _context.Usages.Add(us);
                        _context.SaveChanges();
                        transaction.Commit();
                        return Ok(getUserId);
                    }

                   
                    
                }
                catch
                {
                    transaction.Rollback();
                    return BadRequest();
                }
            }
            
        }
    }
}
