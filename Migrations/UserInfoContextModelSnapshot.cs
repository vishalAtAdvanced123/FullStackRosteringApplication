﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RosteringPractice.DbContexts;

#nullable disable

namespace RosteringPractice.Migrations
{
    [DbContext(typeof(UserInfoContext))]
    partial class UserInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RosteringPractice.Entity.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DesignationList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesignationName = "Trainee"
                        },
                        new
                        {
                            Id = 2,
                            DesignationName = "Jr. Software Developer"
                        },
                        new
                        {
                            Id = 3,
                            DesignationName = "Senior Software Developer"
                        });
                });

            modelBuilder.Entity("RosteringPractice.Entity.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GenderList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenderName = "Male"
                        },
                        new
                        {
                            Id = 2,
                            GenderName = "Female"
                        });
                });

            modelBuilder.Entity("RosteringPractice.Entity.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationName = "Banglore"
                        },
                        new
                        {
                            Id = 2,
                            LocationName = "Vadodara"
                        },
                        new
                        {
                            Id = 3,
                            LocationName = "Ahamadabad"
                        });
                });

            modelBuilder.Entity("RosteringPractice.Entity.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SkillList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SkillName = "C#"
                        },
                        new
                        {
                            Id = 2,
                            SkillName = "Angular"
                        },
                        new
                        {
                            Id = 3,
                            SkillName = "Java"
                        },
                        new
                        {
                            Id = 4,
                            SkillName = "Python"
                        },
                        new
                        {
                            Id = 5,
                            SkillName = "Machine Learning"
                        },
                        new
                        {
                            Id = 6,
                            SkillName = "Web API"
                        },
                        new
                        {
                            Id = 7,
                            SkillName = ".NET"
                        });
                });

            modelBuilder.Entity("RosteringPractice.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.HasIndex("GenderId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("UsersInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesignationId = 1,
                            Email = "Vishalanilrathod@gmail.com",
                            FirstName = "Vishal",
                            GenderId = 1,
                            LastName = "Rathod",
                            LocationId = 1,
                            Password = "Vishal@123",
                            UserName = "vishal.rathod123"
                        },
                        new
                        {
                            Id = 2,
                            DesignationId = 2,
                            Email = "rahulparikh12@gmail.com",
                            FirstName = "Rahul",
                            GenderId = 1,
                            LastName = "Parikh",
                            LocationId = 2,
                            Password = "Rahul@123",
                            UserName = "rahul.rparikh123"
                        },
                        new
                        {
                            Id = 3,
                            DesignationId = 2,
                            Email = "kirangaudapatil@gmail.com",
                            FirstName = "Kiran",
                            GenderId = 1,
                            LastName = "Patil",
                            LocationId = 3,
                            Password = "Kiran@123",
                            UserName = "Kiran.patil321"
                        });
                });

            modelBuilder.Entity("RosteringPractice.Entity.UserSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SkillId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            SkillId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            SkillId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            SkillId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            SkillId = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 6,
                            SkillId = 6,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("RosteringPractice.Entity.Users", b =>
                {
                    b.HasOne("RosteringPractice.Entity.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RosteringPractice.Entity.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RosteringPractice.Entity.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Designation");

                    b.Navigation("Gender");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("RosteringPractice.Entity.UserSkills", b =>
                {
                    b.HasOne("RosteringPractice.Entity.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RosteringPractice.Entity.Users", "Users")
                        .WithMany("SkillforUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("RosteringPractice.Entity.Users", b =>
                {
                    b.Navigation("SkillforUser");
                });
#pragma warning restore 612, 618
        }
    }
}
