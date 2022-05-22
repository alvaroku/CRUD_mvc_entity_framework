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
    public class RolUsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public RolUsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RolUsuario
        public async Task<IActionResult> Index()
        {
              return View(await _context.RolesUsuario.ToListAsync());
        }

        // GET: RolUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RolesUsuario == null)
            {
                return NotFound();
            }

            var rolUsuario = await _context.RolesUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            return View(rolUsuario);
        }

        // GET: RolUsuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] RolUsuario rolUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolUsuario);
        }

        // GET: RolUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RolesUsuario == null)
            {
                return NotFound();
            }

            var rolUsuario = await _context.RolesUsuario.FindAsync(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }
            return View(rolUsuario);
        }

        // POST: RolUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] RolUsuario rolUsuario)
        {
            if (id != rolUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolUsuarioExists(rolUsuario.Id))
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
            return View(rolUsuario);
        }

        // GET: RolUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RolesUsuario == null)
            {
                return NotFound();
            }

            var rolUsuario = await _context.RolesUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            return View(rolUsuario);
        }

        // POST: RolUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RolesUsuario == null)
            {
                return Problem("Entity set 'SistemaControlEntradaSalidaContext.RolesUsuario'  is null.");
            }
            var rolUsuario = await _context.RolesUsuario.FindAsync(id);
            if (rolUsuario != null)
            {
                _context.RolesUsuario.Remove(rolUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolUsuarioExists(int id)
        {
          return _context.RolesUsuario.Any(e => e.Id == id);
        }
    }
}
