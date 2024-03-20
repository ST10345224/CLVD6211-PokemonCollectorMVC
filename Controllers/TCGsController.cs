using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonCollectorMVC.Data;
using PokemonCollectorMVC.Models;

namespace PokemonCollectorMVC.Controllers
{
    public class TCGsController : Controller
    {
        private readonly PokemonCollectorMVCContext _context;

        public TCGsController(PokemonCollectorMVCContext context)
        {
            _context = context;
        }

        // GET: TCGs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TCG.ToListAsync());
        }

        // GET: TCGs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCG = await _context.TCG
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (tCG == null)
            {
                return NotFound();
            }

            return View(tCG);
        }

        // GET: TCGs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TCGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,CardSeries,CardName,CardType")] TCG tCG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tCG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tCG);
        }

        // GET: TCGs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCG = await _context.TCG.FindAsync(id);
            if (tCG == null)
            {
                return NotFound();
            }
            return View(tCG);
        }

        // POST: TCGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CardId,CardSeries,CardName,CardType")] TCG tCG)
        {
            if (id != tCG.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tCG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TCGExists(tCG.CardId))
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
            return View(tCG);
        }

        // GET: TCGs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCG = await _context.TCG
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (tCG == null)
            {
                return NotFound();
            }

            return View(tCG);
        }

        // POST: TCGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tCG = await _context.TCG.FindAsync(id);
            if (tCG != null)
            {
                _context.TCG.Remove(tCG);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TCGExists(string id)
        {
            return _context.TCG.Any(e => e.CardId == id);
        }
    }
}
