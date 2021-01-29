using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WJDH.OA.API.Data;
using WJDH.OA.API.Models;
using WJDH.OA.API.Models.JWTModels;

namespace WJDH.OA.API.JWT
{
    
    public class TokenProvider
    {
        private readonly WJDHOAAPIContext _context;
        readonly TokenProviderOptions _options;
        public TokenProvider(TokenProviderOptions options, WJDHOAAPIContext context)
        {
            _options = options;
            _context = context;
        }
        public async Task<TokenEntity> GenerateToken(WJDHOAAPIContext _context, string Username,string Password,bool isEncrypt = false)
        {
            var identity = await GetIdentity(Username);
            if (identity==null)
            {
                return null;
            }
            var m = await _context.Users.SingleAsync(u => u.Uname == Username);
            if (m==null)
            {
                return new TokenEntity
                {
                    Status = 0,
                    Message = "登陆失败，用户名错误!"
                };
            }
            if (m.IsLock == 1)
            {
                return new TokenEntity
                {
                    Status = 0,
                    Message = "登陆失败,该用户已被锁定，请联系管理员解锁！"
                };
            }
            var model = await _context.Users.SingleAsync(u => u.Uname == Username);
            if (model==null)
            {
                return new TokenEntity
                {
                    Status = 0,
                    Message = "登陆失败,密码错误!"
                };
            }

            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,ToUnixEpochDate(now).ToString(),ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Name,model.Uname,ClaimValueTypes.String),
                new Claim(ClaimTypes.Surname,model.TrueName,ClaimValueTypes.String),
                new Claim(ClaimTypes.Sid,model.ID.ToString(),ClaimValueTypes.Integer32)
            };

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials
                );

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new TokenEntity
            {
                Status = 1,
                UserId = model.ID,
                Message = "登陆成功",
                Access_token = encodeJwt,
                Expires_in = (int)_options.Expiration.TotalSeconds,
                UserName = model.TrueName
            };
            return response;

        }
        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
        private Task<ClaimsIdentity> GetIdentity(string username)
        {
            return Task.FromResult(
                new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "token"),
                new Claim[] {
                new Claim(ClaimTypes.Name,username)
                }));
        }

    }
}
