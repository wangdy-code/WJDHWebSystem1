using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WJDH.OA.API.Data;
using WJDH.OA.API.Models;
using static WJDH.OA.API.Startup;

namespace WJDH.OA.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [WebApiAuthorize]
    public class DaKaController : ControllerBase
    {
        private readonly WJDHOAAPIContext _context;

        public DaKaController(WJDHOAAPIContext context)
        {
            _context = context;
        }

        // GET: api/DaKa
        [HttpGet]
        //获取所有人的打卡数据
        public async Task<ActionResult<IEnumerable<DaKaItem>>> GetDaKaByDate(DateTime start_date, DateTime end_date)
        {
            var data = await _context.Users.Where(u => u.IsLock == 0).Select(x => new
            {
                x.ID,
                x.Uname,
                x.TrueName,
                DaKaIterms = x.DaKaIterms
                .Where(d => d.createTime.Date >= start_date.Date)
                .Where(d => d.createTime.Date <= end_date.Date)
                .Where(d => d.zt == 1),
            }).ToListAsync();
            return new JsonResult(new
            {
                status = 1,
                message = "获取成功",
                data = data
            });
        }

        // GET: api/DaKa/5
        //根据用户id获取打卡数据
        [HttpGet("{id}")]
        public async Task<ActionResult<DaKaItem>> GetDaKaById(int id, DateTime start_date, DateTime end_date)
        {
            var data = await _context.Users.Where(u => u.ID == id).Select(x => new
            {
                x.ID,
                x.Uname,
                x.TrueName,
                DaKaIterms = x.DaKaIterms
                .Where(d => d.createTime.Date >= start_date.Date)
                .Where(d => d.createTime.Date <= end_date.Date)
                .Where(d => d.zt == 1),
            }).ToListAsync();
            return new JsonResult(new
            {
                status = 1,
                message = "获取成功",
                data = data
            });
        }



        // POST: api/DaKa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DaKaItem>> AddDaKaItem(DaKaItem daKaItem)
        {
            string start_timeAM = "06:00";
            string end_timeAM = "08:30";
            string start_timePM = "17:30";
            string end_timePM = "23:59:59";
            TimeSpan dspStartWorkAM = DateTime.Parse(start_timeAM).TimeOfDay;
            TimeSpan dspEndWorkAM = DateTime.Parse(end_timeAM).TimeOfDay;
            TimeSpan dspStartWorkPM = DateTime.Parse(start_timePM).TimeOfDay;
            TimeSpan dspEndWorPM = DateTime.Parse(end_timePM).TimeOfDay;
            int dkcounts=0;
            daKaItem.createTime = daKaItem.createTime.ToLocalTime();
            TimeSpan dkdsp = daKaItem.createTime.TimeOfDay;
            if (dkdsp > dspStartWorkAM && dkdsp < dspEndWorkAM)
            {
                dkcounts = _context.DaKa
                        .Where(d => d.UserID == daKaItem.UserID && d.createTime.TimeOfDay > dspStartWorkAM && d.createTime.TimeOfDay < dspEndWorkAM && d.createTime.Date == daKaItem.createTime.Date)
                        .Count();
            }

            else if (dkdsp > dspStartWorkPM && dkdsp < dspEndWorPM)
            {
                dkcounts = _context.DaKa
                        .Where(d => d.UserID == daKaItem.UserID && d.createTime.TimeOfDay > dspStartWorkAM && d.createTime.TimeOfDay < dspEndWorPM && d.createTime.Date == daKaItem.createTime.Date)
                        .Count();
            }
            else
            {
                return new JsonResult(new
                {
                    status = 0,
                    message = "不在打卡时间范围内！"
                });
            }
            if (dkcounts>=1)
            {
                return new JsonResult(new
                {
                    status = 0,
                    message = "您已打卡！"
                });
            }
                
            if ((dkdsp > dspStartWorkAM && dkdsp < dspEndWorkAM) || (dkdsp > dspStartWorkPM && dkdsp < dspEndWorPM))
            {
                daKaItem.IsValid = 1;
            }
            else
            {
                daKaItem.IsValid = 0;
            }
            _context.DaKa.Add(daKaItem);
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                status = 1,
                message = "添加成功！"
            });
        }
        [HttpPost]
        public async Task<ActionResult<DaKaItem>> AdminAddDaKaItem(DaKaItem daKaItem)
        {

            daKaItem.createTime = daKaItem.createTime.ToLocalTime();
            if (DateTime.Parse(daKaItem.createTime.ToString("T")) >= DateTime.Parse("06:00:00") && DateTime.Parse(daKaItem.createTime.ToString("T")) <= DateTime.Parse("08:30:00") || DateTime.Parse(daKaItem.createTime.ToString("T")) >= DateTime.Parse("17:30:00") && DateTime.Parse(daKaItem.createTime.ToString("T")) <= DateTime.Parse("23:59:59"))
            {
                daKaItem.IsValid = 1;
            }
            else
            {
                daKaItem.IsValid = 0;
            }
            var AdminAddCounts = _context.DaKa.Where(d => d.UserID == daKaItem.UserID).Where(d => d.bq == 1).Where(d => d.createTime.Year == daKaItem.createTime.Month&& d.createTime.Year == daKaItem.createTime.Year).Count();
            if (AdminAddCounts >= 3)
            {
                return new JsonResult(new
                {
                    status = 0,
                    message = "该月补签次数已超过三次,补签失败！"
                });
            }
            daKaItem.bq = 1;
            _context.DaKa.Add(daKaItem);
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                status = 1,
                message = "添加成功！"
            });
        }

        // DELETE: api/DaKa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaKaIterm(int id)
        {
            var daKaIterm = await _context.DaKa.FindAsync(id);
            if (daKaIterm == null)
            {
                return NotFound();
            }

            _context.DaKa.Remove(daKaIterm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
