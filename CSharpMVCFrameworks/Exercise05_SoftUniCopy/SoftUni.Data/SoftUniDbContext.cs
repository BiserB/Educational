using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUni.Models;
using System;

namespace SoftUni.Data
{
    public class SoftUniDbContext : IdentityDbContext<User>
    {
        public SoftUniDbContext(DbContextOptions<SoftUniDbContext> options)
               : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseInstance> CourseInstances { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ResourceType> ResourceTypes { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Course>().HasKey(c => c.Id);

            mb.Entity<CourseInstance>().HasKey(c => c.Id);
            mb.Entity<CourseInstance>().HasOne(ci => ci.Course).WithMany(c => c.Instances).HasForeignKey(ci => ci.CourseId);
            mb.Entity<CourseInstance>().HasOne(ci => ci.Lecturer).WithMany(l => l.Instances).HasForeignKey(ci => ci.LecturerId);

            mb.Entity<Lecture>().HasKey(l => l.Id);
            mb.Entity<Lecture>().HasOne(l => l.Instance).WithMany(ci => ci.Lectures).HasForeignKey(l => l.InstanceId);

            mb.Entity<Resource>().HasKey(r => r.Id);
            mb.Entity<Resource>().HasOne(r => r.Lecture).WithMany(l => l.Resources).HasForeignKey(r => r.LectureId);
            mb.Entity<Resource>().HasOne(r => r.ResourceType).WithMany(rt => rt.Resources).HasForeignKey(r => r.ResourceTypeId);

            mb.Entity<ResourceType>().HasKey(r => r.Id);

            mb.Entity<UserCourse>().HasKey(uc => new { uc.UserId, uc.CourseInstanceId });
            mb.Entity<UserCourse>().HasOne(uc => uc.User).WithMany(u => u.EnrolledCourses).HasForeignKey(uc => uc.UserId);
            mb.Entity<UserCourse>().HasOne(uc => uc.CourseInstance).WithMany(ci => ci.Students).HasForeignKey(uc => uc.CourseInstanceId);

            base.OnModelCreating(mb);
        }
    }
}
