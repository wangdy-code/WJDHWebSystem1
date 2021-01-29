using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WJDH.OA.API.Data;
using WJDH.OA.API.JWT;
using WJDH.OA.API.Models;
using WJDH.OA.API.Models.JWTModels;
using static WJDH.OA.API.Startup;

namespace WJDH.OA.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [WebApiAuthorize]
    public class LoginController : ControllerBase
    {
        private readonly WJDHOAAPIContext _context;
        ILogger logger;
        public LoginController(WJDHOAAPIContext context,ILogger<LoginController> _logger)
        {
            _context = context;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody]User user)
        {
            logger.LogInformation(new JsonResult(user).ToString());
            if (string.IsNullOrEmpty(user.Uname))
            { 
                return new JsonResult(new
                {
                    status = 0,
                    message = "请输入用户名"
                });
            }
            if (string.IsNullOrEmpty(user.Pwd))
            {
                return new JsonResult(new
                {
                    status = 0,
                    message = "请输入密码"
                });
            }
            var siginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdasdasdasdasdasdasdadasdasd"));
            var options = new TokenProviderOptions
            {
                Audience = "audience",
                Issuer = "issuer",
                SigningCredentials = new SigningCredentials(siginKey, SecurityAlgorithms.HmacSha256)
            };
            var tpm = new TokenProvider(options, _context);
            var token = await tpm.GenerateToken(_context, user.Uname, user.Pwd);
            if (token != null)
            {
                return new JsonResult(token);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
