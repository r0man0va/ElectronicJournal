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
        public SelectList TeacherNameSL { get; set; }
        public IQueryable<Teacher> listTeachers { get; set; }
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

            listTeachers = _context.Teachers
                .Include(d => d.Department)
                .Where(i => i.Department.Administrator.ID != i.ID);

            TeacherNameSL = new SelectList(
                listTeachers,
                "ID",
                "FullName"
                );

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
                s => s.Name, s => s.StartDate, s => s.TeacherID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            TeacherNameSL = new SelectList(_context.Teachers,
                "ID", "FullName", departmentToUpdate.TeacherID);


            return Page();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }
    }
}
