using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WJDH.OA.API.Models;

namespace WJDH.OA.API.Data
{
    public class WJDHOAAPIContext : DbContext
    {
        public WJDHOAAPIContext (DbContextOptions<WJDHOAAPIContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<DaKaItem>()
                .HasOne(d => d.User)
                .WithMany(u => u.DaKaIterms);
            modelBuilder.Entity<Blog>()
                .HasOne(b=>b.User)
                .WithMany(u=>u.Blogs);
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.ID)
                .HasName("PrimaryKey_CommentId");
            modelBuilder.Entity<Comment>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(b => b.Comments);
            modelBuilder.Entity<Department>()
                .HasKey(d => d.ID)
                .HasName("PrimaryKey_DepartmentId");
            modelBuilder.Entity<Department>()
                .Property(d => d.ID)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DaKaItem> DaKa { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<QinJia> QinJias { get; set; }
        public DbSet<QinJiaImage> QinJiaImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
