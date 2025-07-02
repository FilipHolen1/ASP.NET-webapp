using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolTracker.DAL;
using SchoolTracker.Model;
using SchoolWebApp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApp.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.ClassYear)
                .ToListAsync();

            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAjax(StudentFilterModel filter)
        {
            var query = _context.Students
                .Include(s => s.ClassYear)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(s =>
                    (s.FirstName + " " + s.LastName).ToLower().Contains(filter.FullName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(s => s.Email != null && s.Email.ToLower().Contains(filter.Email.ToLower()));
            }

            var filteredStudents = await query.ToListAsync();
            return PartialView("_IndexTable", filteredStudents);
        }

        public IActionResult Create()
        {
            FillDropdownValues();
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            FillDropdownValues();
            return View(model);
        }

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = _context.Students
                .Include(s => s.ClassYear)
                .FirstOrDefault(c => c.ID == id);

            if (model == null)
                return NotFound();

            FillDropdownValues();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var student = await _context.Students
                .Include(s => s.ClassYear)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (student == null)
                return NotFound();

            var ok = await TryUpdateModelAsync(student);

            if (ok && ModelState.IsValid)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            FillDropdownValues();
            return View(student);
        }

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "- odaberite -", Value = "" }
            };

            selectItems.AddRange(_context.ClassYears
                .Select(cy => new SelectListItem
                {
                    Text = cy.Name,
                    Value = cy.ID.ToString()
                }));

            ViewBag.ClassYears = selectItems;
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public IActionResult Details(int id)
        {
            var student = _context.Students
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Subject)
                .FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            return View(student);
        }


    }
}
