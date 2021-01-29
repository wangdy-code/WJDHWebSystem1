using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WJDH.OA.API.Models;
using WJDH.OA.API.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace WJDH.OA.API
{
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddJwtBearer(WebApiAuthorizeAttribute.AuthenticationScheme, options =>
                 {
                     options.RequireHttpsMetadata = false;
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("asdasdasdasdasdasdasdadasdasd")),
                         ValidateIssuer = false,
                         ValidIssuer = "https://localhost:44396/",
                         ValidateAudience=false,
                         ValidAudience = "https://localhost:44396/",
                         ValidateLifetime = true,
                         ClockSkew = TimeSpan.Zero
                     };
                 });
            services.AddDbContext<WJDHOAAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
            services.AddControllers();
        }
        public class WebApiAuthorizeAttribute : AuthorizeAttribute
        {
            public const string AuthenticationScheme = "WJDHOAWebApiAuthenticationScheme";

            public WebApiAuthorizeAttribute()
            {
                this.AuthenticationSchemes = AuthenticationScheme;
            }
        } 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
