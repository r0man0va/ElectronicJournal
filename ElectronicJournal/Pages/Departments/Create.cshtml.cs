using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElectronicJournal.Data;
using ElectronicJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public CreateModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }
        public IQueryable<Teacher> listTeachers { get; set; }
        public IActionResult OnGet()
        {
            listTeachers = _context.Teachers
                .Include(d => d.Department)
                .Where(i => i.Department.Administrator.ID != i.ID);

            ViewData["TeacherID"] = new SelectList(
                listTeachers,
                "ID",
                "FullName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
