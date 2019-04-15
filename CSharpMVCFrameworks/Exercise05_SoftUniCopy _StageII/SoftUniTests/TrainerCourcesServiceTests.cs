using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftUni.Common;
using SoftUni.Services.Trainer;
using System;
using System.Linq;

namespace SoftUniTests
{
    [TestClass]
    public class TrainerCourcesServiceTests
    {
        [TestMethod]
        public void GetTrainerPanelDataTest()
        {
            var db = MockResources.GetTestDb();

            var service = new TrainerCoursesService(db);

            var panelData = service.GetTrainerPanelData();

            Assert.AreEqual(3, panelData.Courses.Count);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            var db = MockResources.GetEmptyTestDb();

            var service = new TrainerCoursesService(db);

            var model = new AddCourseBindingModel() { Name = "JavaScript" };

            service.AddCourse(model);

            var courseCount = db.Courses.Count();

            Assert.AreEqual(1, courseCount);
        }

        [TestMethod]
        public void AddNullCourseTest()
        {
            var db = MockResources.GetEmptyTestDb();

            var service = new TrainerCoursesService(db);

            AddCourseBindingModel model = null;

            try
            {
                service.AddCourse(model);
            }
            catch (Exception ex)
            {
                var exeption = ex.GetType();

                Assert.IsTrue(ex.GetType() == typeof(NullReferenceException));

                return;
            }

            Assert.Fail("Expected exception of type " + typeof(NullReferenceException) + " but no exception was thrown.");
        }
    }
}