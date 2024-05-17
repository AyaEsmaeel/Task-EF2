using Azure;
using Microsoft.EntityFrameworkCore;
using P01_Student_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Student_System.Data
{
    internal class StudentSystemContext : DbContext
    {
        public virtual DbSet<Courses> course { get; set; }
        public virtual DbSet<HomeworkSubmissions> Homework { get; set; }
        public virtual DbSet<Resources> resource { get; set; }
        public virtual DbSet<Students> student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Student_System;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Has Many

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Students>()
               .HasMany(e => e.Courses)
               .WithMany(e => e.students)
               .UsingEntity(
                 "StudentCourses",
                l => l.HasOne(typeof(Students)).WithMany().HasForeignKey("StudentsId").HasPrincipalKey(nameof(Students.StudentsId)),
                r => r.HasOne(typeof(Courses)).WithMany().HasForeignKey("CoursesId").HasPrincipalKey(nameof(Courses.CoursesId)),
                j => j.HasKey("StudentsId","CoursesId"));

            modelBuilder.Entity<Students>()
               .HasMany(e => e.HomeworkEnrolled)
               .WithOne(e => e.students)
               .HasForeignKey(e => e.StudentsId)
               .HasPrincipalKey(e => e.StudentsId);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.HomeworkEnrolled)
                .WithOne(e => e.course)
                .HasForeignKey(e => e.CoursesId)
                .HasPrincipalKey(e => e.CoursesId);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.resources)
                .WithOne(e => e.course)
                .HasForeignKey(e => e.CoursesId)
                .HasPrincipalKey(e => e.CoursesId);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.students)
                .WithMany(e => e.Courses)
                .UsingEntity(
                 "StudentCourses",
                l => l.HasOne(typeof(Students)).WithMany().HasForeignKey("StudentsId").HasPrincipalKey(nameof(Students.StudentsId)),
                r => r.HasOne(typeof(Courses)).WithMany().HasForeignKey("CoursesId").HasPrincipalKey(nameof(Courses.CoursesId)),
                j => j.HasKey("StudentsId", "CoursesId"));
            //has one

            modelBuilder.Entity<Resources>()
              .HasOne(e => e.course)
              .WithMany(e => e.resources)
              .HasForeignKey(e => e.CoursesId)
              .HasPrincipalKey(e => e.CoursesId);

            modelBuilder.Entity<HomeworkSubmissions>()
              .HasOne(e => e.students)
              .WithMany(e => e.HomeworkEnrolled)
              .HasForeignKey(e => e.StudentsId)
              .HasPrincipalKey(e => e.StudentsId);

            modelBuilder.Entity<HomeworkSubmissions>()
              .HasOne(e => e.course)
              .WithMany(e => e.HomeworkEnrolled)
              .HasForeignKey(e => e.CoursesId)
              .HasPrincipalKey(e => e.CoursesId);

    

            modelBuilder.Entity<Resources>(
            eb =>
            {
                eb.Property(b => b.Url).HasColumnType("varchar(100)");
                eb.Property(b => b.Name).HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Courses>(
            em =>
            {
            em.Property(m => m.Description).HasColumnType("nvarchar(100)");
            em.Property(m => m.Name).HasColumnType("nvarchar(80)");
            em.Property(m => m.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<HomeworkSubmissions>()
            .Property(e => e.Content)
            .HasColumnType("varchar(100)");

        }
    }
}
