﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WJDH.OA.API.Data;

namespace WJDH.OA.API.Migrations
{
    [DbContext(typeof(WJDHOAAPIContext))]
    [Migration("20210128081401_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("WJDH.OA.API.Models.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("IsValid")
                        .HasColumnType("int");

                    b.Property<string>("Plan")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime");

                    b.Property<int>("zt")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.BlogImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("BlogID");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommentLevel")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentCommentID")
                        .HasColumnType("int");

                    b.Property<int>("ParentUserID")
                        .HasColumnType("int");

                    b.Property<int>("ReplyCommentID")
                        .HasColumnType("int");

                    b.Property<int>("ReplyUserID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Uname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID")
                        .HasName("PrimaryKey_CommentId");

                    b.HasIndex("BlogID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.DaKaIterm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IsValid")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("bq")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime");

                    b.Property<string>("location")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("zt")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("DaKa");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasName("PrimaryKey_DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.QinJia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("QinJias");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.QinJiaImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ImagePath")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("QinJiaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("QinJiaID");

                    b.ToTable("QinJiaImages");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("IsLock")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("char(11)");

                    b.Property<string>("Pwd")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sex")
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("TrueName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Uname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("_openid")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("role")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.Blog", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.BlogImage", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.Blog", "Blog")
                        .WithMany("BlogImages")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.Comment", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WJDH.OA.API.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.DaKaIterm", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.User", "User")
                        .WithMany("DaKaIterms")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.QinJia", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.User", "User")
                        .WithMany("QinJias")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.QinJiaImage", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.QinJia", "QinJia")
                        .WithMany("QinJiaImages")
                        .HasForeignKey("QinJiaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QinJia");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.User", b =>
                {
                    b.HasOne("WJDH.OA.API.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.Blog", b =>
                {
                    b.Navigation("BlogImages");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.QinJia", b =>
                {
                    b.Navigation("QinJiaImages");
                });

            modelBuilder.Entity("WJDH.OA.API.Models.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Comments");

                    b.Navigation("DaKaIterms");

                    b.Navigation("QinJias");
                });
#pragma warning restore 612, 618
        }
    }
}
