using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public CreateModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var newStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                newStudent,
                "student",   
                s => s.FirstName, s => s.LastName, s => s.EnrollmentDate,
                s => s.GroupName, s => s.DOB, s => s.PhoneNumber))
            {
                _context.Students.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
