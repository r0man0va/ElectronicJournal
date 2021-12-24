using ElectronicJournal.Data;
using ElectronicJournal.Models;
using ElectronicJournal.Models.JournalViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicJournal.Pages.Teachers
{
    public class InstructorCoursesPageModel : PageModel
    {
        public List<AssignedCourseData> AssignedCourseDataList;

        public void PopulateAssignedCourseData(ElectronicJournalContext context,
                                               Teacher teacher)
        {
            var allCourses = context.Courses;
            var instructorCourses = new HashSet<int>(
                teacher.Courses.Select(c => c.CourseID));
            AssignedCourseDataList = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
        }
    }
}