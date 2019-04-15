using SoftUni.Common;
using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Services.Trainer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni.Services.Trainer
{
    public class TrainerCoursesService : BaseService, ITrainerCoursesService
    {
        public TrainerCoursesService(SoftUniDbContext db)
                                    : base(db)
        {
        }

        public TrainerPanelViewModel GetTrainerPanelData()
        {
            var resources = this.db.Resources.ToList();

            var courses = this.db.Courses.ToList();

            var courseViews = new List<CourseViewModel>(courses.Count);

            foreach (var course in courses)
            {
                var courseInstancesCount = this.db.CourseInstances
                                             .Where(ci => ci.CourseId == course.Id && ci.IsDeleted == false)
                                             .Count();

                courseViews.Add(new CourseViewModel()
                {
                    Id = course.Id,
                    Name = course.Name,
                    InstanceCount = courseInstancesCount
                });
            }

            var viewModel = new TrainerPanelViewModel() { Courses = courseViews };

            var resourceTypes = new Dictionary<string, int>();

            return viewModel;
        }

        public void AddCourse(AddCourseBindingModel model)
        {
            var course = new Course() { Name = model.Name };

            this.db.Courses.Add(course);

            this.db.SaveChanges();
        }

        public CourseViewModel GetDetails(Course course)
        {
            var instances = this.db.CourseInstances
                                   .Where(ci => ci.CourseId == course.Id && ci.IsDeleted == false)
                                   .Select(ci => new InstanceViewModel()
                                   {
                                       Id = ci.Id,
                                       Name = ci.Name,
                                       StartDate = ci.StartDate,
                                       EndDate = ci.EndDate,
                                       Trainer = ci.Trainer.FullName
                                   })
                                   .ToList();

            var viewModel = new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                Instances = instances,
                InstanceCount = instances.Count
            };

            return viewModel;
        }

        public Course GetCourse(int id)
        {
            var course = this.db.Courses.FirstOrDefault(c => c.Id == id);

            return course;
        }
    }
}