using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GastroMatch.Admin.Data;
using GastroMatch.Admin.Models;

namespace GastroMatch.Admin.Controllers
{
    public class PlatosController : Controller
    {
        private readonly GastroMatchContext _context;

        public PlatosController(GastroMatchContext context)
        {
            _context = context;
        }

        // GET: Platos
        public async Task<IActionResult> Index()
        {
            var platos = await _context.Platos
                .Include(p => p.Restaurante)
                .ThenInclude(r => r!.Categoria)
                .ToListAsync();
            return View(platos);
        }

        // GET: Platos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var plato = await _context.Platos
                .Include(p => p.Restaurante)
                .ThenInclude(r => r!.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plato == null)
                return NotFound();

            return View(plato);
        }

        // GET: Platos/Create
        public IActionResult Create()
        {
            ViewData["Categorias"] = new SelectList(_context.Categorias, "Id", "Nombre");
            ViewData["RestauranteId"] = new SelectList(Enumerable.Empty<SelectListItem>());
            return View();
        }

        // POST: Platos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Calorias,RestauranteId")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recargar dropdowns en caso de error
            var restaurante = await _context.Restaurantes.FindAsync(plato.RestauranteId);
            var categoriaId = restaurante?.CategoriaId ?? 0;

            ViewData["Categorias"] = new SelectList(_context.Categorias, "Id", "Nombre", categoriaId);
            ViewData["RestauranteId"] = new SelectList(
                await _context.Restaurantes.Where(r => r.CategoriaId == categoriaId).ToListAsync(),
                "Id", "Nombre", plato.RestauranteId);

            return View(plato);
        }

        // GET: Platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var plato = await _context.Platos
                .Include(p => p.Restaurante)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plato == null)
                return NotFound();

            var categoriaId = plato.Restaurante?.CategoriaId ?? 0;

            ViewData["Categorias"] = new SelectList(_context.Categorias, "Id", "Nombre", categoriaId);
            ViewData["RestauranteId"] = new SelectList(
                await _context.Restaurantes.Where(r => r.CategoriaId == categoriaId).ToListAsync(),
                "Id", "Nombre", plato.RestauranteId);

            return View(plato);
        }

        // POST: Platos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Calorias,RestauranteId")] Plato plato)
        {
            if (id != plato.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Recargar dropdowns en caso de error
            var restaurante = await _context.Restaurantes.FindAsync(plato.RestauranteId);
            var categoriaId = restaurante?.CategoriaId ?? 0;

            ViewData["Categorias"] = new SelectList(_context.Categorias, "Id", "Nombre", categoriaId);
            ViewData["RestauranteId"] = new SelectList(
                await _context.Restaurantes.Where(r => r.CategoriaId == categoriaId).ToListAsync(),
                "Id", "Nombre", plato.RestauranteId);

            return View(plato);
        }

        // GET: Platos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var plato = await _context.Platos
                .Include(p => p.Restaurante)
                .ThenInclude(r => r!.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plato == null)
                return NotFound();

            return View(plato);
        }

        // POST: Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plato = await _context.Platos.FindAsync(id);

            if (plato != null)
            {
                _context.Platos.Remove(plato);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Platos/GetRestaurantesByCategoria?categoriaId=1
        // Endpoint para el dropdown en cascada (Categoría -> Restaurante)
        [HttpGet]
        public async Task<JsonResult> GetRestaurantesByCategoria(int categoriaId)
        {
            var restaurantes = await _context.Restaurantes
                .Where(r => r.CategoriaId == categoriaId)
                .Select(r => new { r.Id, r.Nombre })
                .OrderBy(r => r.Nombre)
                .ToListAsync();

            return Json(restaurantes);
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(p => p.Id == id);
        }
    }
}
