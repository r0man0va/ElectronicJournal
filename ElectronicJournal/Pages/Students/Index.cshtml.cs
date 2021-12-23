using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public IndexModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string GroupSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Student> Student { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            GroupSort = (sortOrder == "group_default") ? "group_desc" : "group_default";

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "group_default":
                    studentsIQ = studentsIQ.OrderBy(s => s.GroupName);
                    break;
                case "group_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.GroupName);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            Student = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
