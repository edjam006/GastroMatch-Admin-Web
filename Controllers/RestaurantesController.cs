using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastroMatch.Admin.Data;
using GastroMatch.Admin.Models;

namespace GastroMatch.Admin.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly GastroMatchContext _context;

        public RestaurantesController(GastroMatchContext context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            var restaurantes = await _context.Restaurantes.ToListAsync();
            return View(restaurantes);
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var restaurante = await _context.Restaurantes
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurante == null)
                return NotFound();

            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Email,RUC")] Restaurante restaurante)
        {
            // Validación extra del RUC en el Back-End
            if (!string.IsNullOrEmpty(restaurante.RUC))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(restaurante.RUC, @"^\d{13}$"))
                {
                    ModelState.AddModelError("RUC", "El RUC debe tener exactamente 13 caracteres numéricos.");
                }
                else if (await _context.Restaurantes.AnyAsync(r => r.RUC == restaurante.RUC))
                {
                    ModelState.AddModelError("RUC", "Ya existe un restaurante registrado con este RUC.");
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(restaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var restaurante = await _context.Restaurantes.FindAsync(id);

            if (restaurante == null)
                return NotFound();

            return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Email,RUC")] Restaurante restaurante)
        {
            if (id != restaurante.Id)
                return NotFound();

            // Validación extra del RUC en el Back-End
            if (!string.IsNullOrEmpty(restaurante.RUC))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(restaurante.RUC, @"^\d{13}$"))
                {
                    ModelState.AddModelError("RUC", "El RUC debe tener exactamente 13 caracteres numéricos.");
                }
                else if (await _context.Restaurantes.AnyAsync(r => r.RUC == restaurante.RUC && r.Id != restaurante.Id))
                {
                    ModelState.AddModelError("RUC", "Ya existe un restaurante registrado con este RUC.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestauranteExists(restaurante.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var restaurante = await _context.Restaurantes
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurante == null)
                return NotFound();

            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);

            if (restaurante != null)
            {
                _context.Restaurantes.Remove(restaurante);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RestauranteExists(int id)
        {
            return _context.Restaurantes.Any(r => r.Id == id);
        }
    }
}
