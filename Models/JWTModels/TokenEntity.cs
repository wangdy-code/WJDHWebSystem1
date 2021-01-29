using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WJDH.OA.API.Models.JWTModels
{
    public class TokenEntity
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Access_token { get; set; }
        public int Expires_in { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
