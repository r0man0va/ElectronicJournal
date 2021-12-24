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
    public class DetailsModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public DetailsModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

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
    }
}
