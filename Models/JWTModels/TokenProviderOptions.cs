using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models.JWTModels
{
    public class TokenProviderOptions
    {
        public string Issuer { get; set; }
        /// <summary>
        /// 订阅者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间间隔
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);
        public SigningCredentials SigningCredentials { get; set; }
    }
}
