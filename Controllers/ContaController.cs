using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class ContaController : Controller
    {
        private readonly ContaContexto _context;

        public ContaController(ContaContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string ordem)
        {
            ViewData["NomeParm"] = String.IsNullOrEmpty(ordem) ? "ValorPagar_desc" : "";
            ViewData["DataParm"] = ordem == "Data" ? "data_desc" : "Data";
            var contas = from est in _context.Conta
                                     select est;
            switch (ordem)
            {
                case "ValorPagar_desc":
                    contas = contas.OrderByDescending(est => est.ValorPagar);
                    break;
                case "Data":
                    contas = contas.OrderBy(est => est.KwGasto);
                    break;
                case "data_desc":
                    contas = contas.OrderByDescending(est => est.MediaDeConsumo);
                    break;
                default:
                    contas = contas.OrderBy(est => est.DataDeLeitura);
                    break;
            }
            //return View(await _context.Estudantes.ToListAsync());
            return View(await contas.AsNoTracking().ToListAsync());
        }

        // GET: Conta
    /*    public async Task<IActionResult> Index()
        {
            return View(await _context.Conta.ToListAsync());
        }
    */
        // GET: Conta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaDeLuz = await _context.Conta
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contaDeLuz == null)
            {
                return NotFound();
            }

            return View(contaDeLuz);
        }

        // GET: Conta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDeLeitura,NumLeitura,KwGasto,ValorPagar,DataDoPagamento,MediaDeConsumo")] ContaDeLuz contaDeLuz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaDeLuz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaDeLuz);
        }

        // GET: Conta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaDeLuz = await _context.Conta.SingleOrDefaultAsync(m => m.Id == id);
            if (contaDeLuz == null)
            {
                return NotFound();
            }
            return View(contaDeLuz);
        }

        // POST: Conta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDeLeitura,NumLeitura,KwGasto,ValorPagar,DataDoPagamento,MediaDeConsumo")] ContaDeLuz contaDeLuz)
        {
            if (id != contaDeLuz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaDeLuz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaDeLuzExists(contaDeLuz.Id))
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
            return View(contaDeLuz);
        }

        // GET: Conta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaDeLuz = await _context.Conta
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contaDeLuz == null)
            {
                return NotFound();
            }

            return View(contaDeLuz);
        }

        // POST: Conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaDeLuz = await _context.Conta.SingleOrDefaultAsync(m => m.Id == id);
            _context.Conta.Remove(contaDeLuz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaDeLuzExists(int id)
        {
            return _context.Conta.Any(e => e.Id == id);
        }
    }
}
