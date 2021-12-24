using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Pages.Teachers
{
    public class EditModel : InstructorCoursesPageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public EditModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher = await _context.Teachers
                .Include(i => i.Courses)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Teacher == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(_context, Teacher);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherToUpdate = await _context.Teachers
                .Include(i => i.Courses)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (teacherToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Teacher>(
                teacherToUpdate,
                "Teacher",
                i => i.FirstName, i => i.LastName,
                i => i.DOB, i => i.PhoneNumber))
            {
                UpdateTeacherCourses(selectedCourses, teacherToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateTeacherCourses(selectedCourses, teacherToUpdate);
            PopulateAssignedCourseData(_context, teacherToUpdate);
            return Page();
        }

        public void UpdateTeacherCourses(string[] selectedCourses,
                                            Teacher teacherToUpdate)
        {
            if (selectedCourses == null)
            {
                teacherToUpdate.Courses = new List<Course>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var teacherCourses = new HashSet<int>
                (teacherToUpdate.Courses.Select(c => c.CourseID));
            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!teacherCourses.Contains(course.CourseID))
                    {
                        teacherToUpdate.Courses.Add(course);
                    }
                }
                else
                {
                    if (teacherCourses.Contains(course.CourseID))
                    {
                        var courseToRemove = teacherToUpdate.Courses.Single(
                                                        c => c.CourseID == course.CourseID);
                        teacherToUpdate.Courses.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
