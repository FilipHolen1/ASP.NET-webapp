using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolTracker.DAL;
using SchoolTracker.Model;

namespace SchoolWebApp.Web.Controllers
{
    [Route("profesoriiiiii")]
    public class ProfesorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var profesors = await _context.Profesors.Include(p => p.Subjects).ToListAsync();
            return View(profesors);
        }

        private void PopulateSubjects(List<int>? selectedIds = null)
        {
            var subjects = _context.Subjects
                .Select(s => new SelectListItem
                {
                    Value = s.ID.ToString(),
                    Text = s.Name
                }).ToList();

            ViewBag.Subjects = subjects;
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            PopulateSubjects();
            return View(new Profesor());
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profesor profesor, List<int> SelectedSubjectIds)
        {
            if (ModelState.IsValid)
            {
                profesor.Subjects = new List<Subject>();
                if (SelectedSubjectIds != null)
                {
                    profesor.Subjects = _context.Subjects
                        .Where(s => SelectedSubjectIds.Contains(s.ID)).ToList();
                }

                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateSubjects(SelectedSubjectIds);
            return View(profesor);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var profesor = await _context.Profesors
                .Include(p => p.Subjects)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (profesor == null)
                return NotFound();

            PopulateSubjects(profesor.Subjects.Select(s => s.ID).ToList());
            return View(profesor);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Profesor profesor, List<int> SelectedSubjectIds)
        {
            if (id != profesor.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProfesor = await _context.Profesors
                        .Include(p => p.Subjects)
                        .FirstOrDefaultAsync(p => p.ID == id);

                    if (existingProfesor == null)
                        return NotFound();

                    existingProfesor.FirstName = profesor.FirstName;
                    existingProfesor.LastName = profesor.LastName;
                    existingProfesor.Email = profesor.Email;

                    existingProfesor.Subjects.Clear();
                    if (SelectedSubjectIds != null)
                    {
                        var subjects = await _context.Subjects
                            .Where(s => SelectedSubjectIds.Contains(s.ID))
                            .ToListAsync();
                        existingProfesor.Subjects = subjects;
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Problem("Concurrency error occurred.");
                }
            }

            PopulateSubjects(SelectedSubjectIds);
            return View(profesor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var profesor = _context.Profesors.Find(id);
            if (profesor != null)
            {
                _context.Profesors.Remove(profesor);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
