using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CakesController : Controller
    {
        private readonly WebAppContext _context;

        public CakesController(WebAppContext context)
        {
            _context = context;
        }

        // GET: Cakes
        public async Task<IActionResult> Index()
        {
              return _context.Cake != null ? 
                          View(await _context.Cake.ToListAsync()) :
                          Problem("Entity set 'WebAppContext.Cake'  is null.");
        }
        // GET: Cakes/ShowSearchForm
        public IActionResult ShowSearchForm()
        {
            return _context.Cake != null ?
                        View() :
                        Problem("Entity set 'WebAppContext.Cake'  is null.");
        }
        // GET: Cakes/ShowSearchResults
        public string ShowSearchResults(string SearchPhrase)
        {
            if (_context.Cake != null)
            {
                return "Result: " + SearchPhrase;
            }
            else
            {
                return "";
            }
        }

        // GET: Cakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .FirstOrDefaultAsync(m => m.id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // GET: Cakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,flavour")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cake);
        }

        // GET: Cakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }
            return View(cake);
        }

        // POST: Cakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,flavour")] Cake cake)
        {
            if (id != cake.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeExists(cake.id))
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
            return View(cake);
        }

        // GET: Cakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .FirstOrDefaultAsync(m => m.id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // POST: Cakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cake == null)
            {
                return Problem("Entity set 'WebAppContext.Cake'  is null.");
            }
            var cake = await _context.Cake.FindAsync(id);
            if (cake != null)
            {
                _context.Cake.Remove(cake);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeExists(int id)
        {
          return (_context.Cake?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
