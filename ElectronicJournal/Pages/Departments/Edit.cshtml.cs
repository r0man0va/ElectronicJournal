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

namespace ElectronicJournal.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public EditModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments.FindAsync(id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var departmentToUpdate = await _context.Departments.FindAsync(id);

            if (departmentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Department>(
                departmentToUpdate,
                "department",
                s => s.Name, s => s.StartDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }
    }
}
