using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDnevnik.Models;

namespace EDnevnik.Controllers
{
    public class UcenikController : Controller
    {
        private readonly EDnevnikContext _context;

        public UcenikController(EDnevnikContext context)
        {
            _context = context;
        }

        // GET: Ucenik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ucenik.ToListAsync());
        }

        // GET: Ucenik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ucenik == null)
            {
                return NotFound();
            }

            return View(ucenik);
        }

        // GET: Ucenik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ucenik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Prezime,jmbg,datumRodenja,napomena")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucenik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ucenik);
        }

        // GET: Ucenik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenik.FindAsync(id);
            if (ucenik == null)
            {
                return NotFound();
            }
            return View(ucenik);
        }

        // POST: Ucenik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ime,Prezime,jmbg,datumRodenja,napomena")] Ucenik ucenik)
        {
            if (id != ucenik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucenik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcenikExists(ucenik.ID))
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
            return View(ucenik);
        }

        // GET: Ucenik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ucenik == null)
            {
                return NotFound();
            }

            return View(ucenik);
        }

        // POST: Ucenik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ucenik = await _context.Ucenik.FindAsync(id);
            _context.Ucenik.Remove(ucenik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcenikExists(int id)
        {
            return _context.Ucenik.Any(e => e.ID == id);
        }
    }
}
