using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestRanking.Data;

namespace TestRanking.Controllers
{
    public class TiendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tiendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTiendas.ToListAsync());
        }

        // GET: Tiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTiendas = await _context.TblTiendas
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            ViewBag.Puntos = _context.TblPuntos.Where(p => p.IdTienda == id).Count();
            ViewBag.NPuntos = _context.TblPuntos.Count();
            if (tblTiendas == null)
            {
                return NotFound();
            }

            return View(tblTiendas);
        }

        // GET: Tiendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTienda,NombreTienda,Descripcion,Logo,Imagen")] TblTiendas tblTiendas, IFormFile Logo, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                var path2 = string.Empty;

                if (Imagen != null && Imagen.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images",
                        String.Format("{0}{1}", DateTime.Now.Year, Imagen.FileName));

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Imagen.CopyToAsync(stream);
                    }

                    path = $"/images/{DateTime.Now.Year}{Imagen.FileName}";
                }
                if (Logo != null && Logo.Length > 0)
                {
                    path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\logos",
                        String.Format("{0}{1}", DateTime.Now.Year, Logo.FileName));

                    using (var stream = new FileStream(path2, FileMode.Create))
                    {
                        await Logo.CopyToAsync(stream);
                    }

                    path2 = $"/logos/{DateTime.Now.Year}{Logo.FileName}";
                }
                tblTiendas.Logo = path2;
                tblTiendas.Imagen = path;
                _context.Add(tblTiendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTiendas);
        }

        // GET: Tiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTiendas = await _context.TblTiendas.FindAsync(id);
            if (tblTiendas == null)
            {
                return NotFound();
            }
            return View(tblTiendas);
        }

        // POST: Tiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTienda,NombreTienda,Descripcion,Logo,Imagen")] TblTiendas tblTiendas)
        {
            if (id != tblTiendas.IdTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTiendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTiendasExists(tblTiendas.IdTienda))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblTiendas);
        }

        // GET: Tiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTiendas = await _context.TblTiendas
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tblTiendas == null)
            {
                return NotFound();
            }

            return View(tblTiendas);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTiendas = await _context.TblTiendas.FindAsync(id);
            _context.TblTiendas.Remove(tblTiendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTiendasExists(int id)
        {
            return _context.TblTiendas.Any(e => e.IdTienda == id);
        }
    }
}
