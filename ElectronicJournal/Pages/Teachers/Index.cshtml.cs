using ElectronicJournal.Models;
using ElectronicJournal.Models.JournalViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ElectronicJournal.Data.ElectronicJournalContext _context;

        public IndexModel(ElectronicJournal.Data.ElectronicJournalContext context)
        {
            _context = context;
        }

        public TeacherIndexData TeacherData { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            TeacherData = new TeacherIndexData();
            TeacherData.Teachers = await _context.Teachers
                .Include(i => i.Courses)
                    .ThenInclude(c => c.Department)
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                TeacherID = id.Value;
                Teacher teacher = TeacherData.Teachers
                    .Where(i => i.ID == id.Value).Single();
                TeacherData.Courses = teacher.Courses;
            }

            if (courseID != null)
            {
                CourseID = courseID.Value;
                var selectedCourse = TeacherData.Courses
                    .Where(x => x.CourseID == courseID).Single();
                await _context.Entry(selectedCourse)
                              .Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                TeacherData.Enrollments = selectedCourse.Enrollments;
            }
        }
    }
}