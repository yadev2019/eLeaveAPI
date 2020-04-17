using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLeaveAPI.Helper;
using eLeaveAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveEventController : ControllerBase
    {
        readonly DBContext _context;
        public ApproveEventController(DBContext context)
        {
            _context = context;
        }
        // POST: api/ApproveEvent
        [HttpPost]
        public IActionResult Post(ApproveEvent AppEvt)
        {

            if (AppEvt.eId != null && AppEvt.userId != null && AppEvt.statusCode != null && AppEvt.Topic != null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var result = _context.Events.FirstOrDefault(o => o.Id == AppEvt.eId && o.userId == AppEvt.userId);
                        #region
                        if (result != null)
                        {
                            //Event ev = new Event();
                            result.Id = (int)AppEvt.eId;
                            result.statusId = (int)AppEvt.statusCode;
                            result.Updated_at = DateTime.Now;
                            _context.Events.Update(result);
                            _context.SaveChanges();

                            if (AppEvt.statusCode == (int)EnumHelper.Status.Approve)
                            {
                                var usage = _context.Usages.FirstOrDefault(o => o.userId == AppEvt.userId);
                                if (usage != null)
                                {
                                    if (result.Topic == (int)EnumHelper.Refer.Hiliday)
                                    {
                                        usage.Holiday = (usage.Holiday - result.Amount);
                                    }
                                    else if (result.Topic == (int)EnumHelper.Refer.Personal)
                                    {
                                        usage.Personal = (usage.Holiday - result.Amount);
                                    }
                                    else if(result.Topic == (int)EnumHelper.Refer.Sick)
                                    {
                                        usage.Sick = (usage.Holiday - result.Amount);
                                    }
                                    usage.Updated_at = DateTime.Now;
                                    _context.Usages.Update(usage);
                                    _context.SaveChanges();
                                }
                            }

                            transaction.Commit();
                        }
                        #endregion

                        return Ok(new { message = "Successfully", success = true });
                    }
                    catch
                    {
                        transaction.Rollback();
                        return BadRequest();
                    }
                }

            }
            else
            {
                return Ok(new { message = "Data model Not found", success = false });
            }
        }
    }
}
