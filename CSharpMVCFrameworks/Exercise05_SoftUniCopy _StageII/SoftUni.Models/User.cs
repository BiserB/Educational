using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.EnrolledCourses = new List<UserCourse>();
            this.Instances = new List<CourseInstance>();
        }

        public string FullName { get; set; }

        public ICollection<UserCourse> EnrolledCourses { get; set; }

        public ICollection<CourseInstance> Instances { get; set; }
    }
}