using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WJDH.OA.API.Data;
using WJDH.OA.API.Models;
using static WJDH.OA.API.Startup;

namespace WJDH.OA.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [WebApiAuthorize]
    public class UsersController : ControllerBase
    {
        private readonly WJDHOAAPIContext _context;

        public UsersController(WJDHOAAPIContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var list = await _context.Users.ToListAsync();
            return new JsonResult(new
            {
                status=1,
                message = "获取成功",
                data = list
            });
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("{DepartmentID}")]
        public async Task<ActionResult> GetUserByDepartmentID(int DepartmentID)
        {
            var list = await _context.Users.Where(u => u.DepartmentID == DepartmentID).ToListAsync();
            return new JsonResult(new
            {
                status = 1,
                message = "获取成功",
                data = list
            });
        }
        


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                status = 1,
                message = "添加成功！"
            });
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(List<User> users)
        {
            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();
            return new JsonResult(new
            {
                status = 1,
                message = "添加成功！"
            });
        }
        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(List<int> ids)
        {
            var users = _context.Users.Where(u => ids.Contains(u.ID));
            foreach (var user in users)
            {
                user.IsLock = 1;
            }
            await _context.SaveChangesAsync();

            return new JsonResult(new
            {
                status = 1,
                message = "删除成功！"
            });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
