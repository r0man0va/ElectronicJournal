using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public DeleteModel(ElectronicJournal.Data.ElectronicJournalContext context)
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

            Teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.ID == id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = await _context.Teachers
                 .Include(i => i.Courses)
                 .SingleAsync(i => i.ID == id);

            if (teacher == null)
            {
                return RedirectToPage("./Index");
            }

            var departments = await _context.Departments
                .Where(d => d.TeacherID == id)
                .ToListAsync();
            departments.ForEach(d => d.TeacherID = null);

            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
