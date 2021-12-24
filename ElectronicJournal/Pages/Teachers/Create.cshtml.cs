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
    public class CreateModel : InstructorCoursesPageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;
        private readonly ILogger<InstructorCoursesPageModel> _logger;
        public CreateModel(ElectronicJournal.Data.ElectronicJournalContext context,
            ILogger<InstructorCoursesPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var teacher = new Teacher();
            teacher.Courses = new List<Course>();

            PopulateAssignedCourseData(_context, teacher);
            return Page();
        }

        [BindProperty]
        public Teacher Teacher { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newTeacher = new Teacher();

            if (selectedCourses.Length > 0)
            {
                newTeacher.Courses = new List<Course>();
                _context.Courses.Load();
            }

            foreach (var course in selectedCourses)
            {
                var foundCourse = await _context.Courses.FindAsync(int.Parse(course));
                if (foundCourse != null)
                {
                    newTeacher.Courses.Add(foundCourse);
                }
                else
                {
                    _logger.LogWarning("Курс {course} не найден!", course);
                }
            }

            try
            {
                if (await TryUpdateModelAsync<Teacher>(
                                newTeacher,
                                "Teacher",
                                i => i.FirstName, i => i.LastName,
                                i => i.DOB, i => i.PhoneNumber))
                {
                    _context.Teachers.Add(newTeacher);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            PopulateAssignedCourseData(_context, newTeacher);
            return Page();
        }
    }
}
