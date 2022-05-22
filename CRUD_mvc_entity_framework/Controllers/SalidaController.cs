using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_mvc.Models;

namespace CRUD_mvc.Controllers
{
    public class SalidaController : Controller
    {
        private readonly AppDbContext _context;

        public SalidaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Salida
        public async Task<IActionResult> Index()
        {
            var sistemaControlEntradaSalidaContext = _context.Salidas.Include(s => s.Usuario);
            return View(await sistemaControlEntradaSalidaContext.ToListAsync());
        }

        // GET: Salida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salidas == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salida == null)
            {
                return NotFound();
            }

            return View(salida);
        }

        // GET: Salida/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: Salida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,HoraSalida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", salida.UsuarioId);
            return View(salida);
        }

        // GET: Salida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salidas == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas.FindAsync(id);
            if (salida == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", salida.UsuarioId);
            return View(salida);
        }

        // POST: Salida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,HoraSalida")] Salida salida)
        {
            if (id != salida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalidaExists(salida.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", salida.UsuarioId);
            return View(salida);
        }

        // GET: Salida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salidas == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salida == null)
            {
                return NotFound();
            }

            return View(salida);
        }

        // POST: Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salidas == null)
            {
                return Problem("Entity set 'SistemaControlEntradaSalidaContext.Salidas'  is null.");
            }
            var salida = await _context.Salidas.FindAsync(id);
            if (salida != null)
            {
                _context.Salidas.Remove(salida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalidaExists(int id)
        {
          return _context.Salidas.Any(e => e.Id == id);
        }
    }
}
