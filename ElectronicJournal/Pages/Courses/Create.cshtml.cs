using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public CreateModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var newCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                 newCourse,
                 "course",   
                 s => s.CourseID, s => s.DepartmentID, s => s.Title))
            {
                _context.Courses.Add(newCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateDepartmentsDropDownList(_context, newCourse.DepartmentID);
            return Page();
        }
    }
}
