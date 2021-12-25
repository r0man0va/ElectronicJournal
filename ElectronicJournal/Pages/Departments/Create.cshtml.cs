using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Pages.Departments
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
        ViewData["TeacherID"] = new SelectList(_context.Teachers, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
