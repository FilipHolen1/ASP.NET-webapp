using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolTracker.DAL;
using SchoolTracker.Model;
using SchoolWebApp.Web.Models; // Ako ti treba za filter, može ostati

namespace SchoolWebApp.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Professor/
        public async Task<IActionResult> Index()
        {
            // Učitaj profesore sa predmetima koje predaju
            var profesors = await _context.Profesors
                .Include(p => p.Subjects)
                .ToListAsync();

            return View(profesors); // Vraćamo listu profesora u View
        }

        // Ako želiš imati ajax filter za profesore, možeš napraviti nešto slično,
        // ovdje je primjer bez filtera, možeš kasnije prilagoditi
        [HttpPost]
        public async Task<IActionResult> IndexAjax(string fullName)
        {
            var query = _context.Profesors.AsQueryable();

            if (!string.IsNullOrEmpty(fullName))
            {
                query = query.Where(p =>
                    (p.FirstName + " " + p.LastName).ToLower().Contains(fullName.ToLower()));
            }

            var filteredProfesors = await query.ToListAsync();
            return PartialView("_IndexTable", filteredProfesors);
            // Pobrinite se da postoji partial view koji prikazuje profesore
        }

        // GET: /Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Professor/Create
        [HttpPost]
        public async Task<IActionResult> Create(Profesor model)
        {
            if (ModelState.IsValid)
            {
                _context.Profesors.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Professor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: /Professor/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Profesor model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Profesors.Any(e => e.ID == id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(model);
        }

        // GET: /Professor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: /Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesors.Remove(profesor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
