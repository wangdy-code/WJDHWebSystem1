using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WJDH.OA.API.Data;
using WJDH.OA.API.Models;

namespace WJDH.OA.API
{
    /// <summary>
    /// 测试使用的context
    /// </summary>
    //public class TestContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<DaKaIterm> DaKa { get; set; }
    //    public DbSet<Blog> Blogs { get; set; }
    //    public DbSet<BlogImage> BlogImages { get; set; }
    //    public DbSet<QinJia> QinJias { get; set; }
    //    public DbSet<QinJiaImage> QinJiaImages { get; set; }
    //    public DbSet<Comment> Comments { get; set; }
    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlServer("Server=localhost;Database=WJDH.OA;User ID=sa;Password=sa;");
    //}
    public class Program
    {
        
        public static void Main(string[] args)
        {
            ///添加测试数据
            //using (var db = new TestContext())
            //{
            //    // Create
            //    Console.WriteLine("Inserting a new User");
            //    User user = new User();
            //    user.TrueName = "wdy";
            //    user.Uname = "admin";
            //    user.Pwd = "admin";
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
