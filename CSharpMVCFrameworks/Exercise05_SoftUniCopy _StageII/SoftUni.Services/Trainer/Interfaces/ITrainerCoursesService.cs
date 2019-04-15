using SoftUni.Common;
using SoftUni.Models;

namespace SoftUni.Services.Trainer.Interfaces
{
    public interface ITrainerCoursesService
    {
        TrainerPanelViewModel GetTrainerPanelData();

        void AddCourse(AddCourseBindingModel model);

        Course GetCourse(int id);

        CourseViewModel GetDetails(Course course);
    }
}