using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas_CP.Models;
using GestaoTarefas_CP.Models.ViewModels;

namespace GestaoTarefas_CP.Controllers
{
    public class EscolasController : Controller
    {
        public int Tamanho_Pagina = 3;
        private readonly TarefasDbContext _context;

        public EscolasController(TarefasDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        public IActionResult Index(int pagina = 1, string searchString = null)
        {

            var Escola = from s in _context.Escola
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Escola = Escola.Where(s => s.NomeEscola.Contains(searchString));
            }

            decimal nEscolas = Escola.Count();
            int nPagina = ((int)nEscolas / Tamanho_Pagina);

            if (nEscolas % Tamanho_Pagina == 0)
            {
                nPagina = 1;
            }

            EscolaViewModel vm = new EscolaViewModel
            {
                Escolas = Escola
                .OrderBy(s => s.NomeEscola)
                .Skip((pagina - 1) * Tamanho_Pagina)
                .Take(Tamanho_Pagina),
                Pagina_Atual = pagina,
                Primeira_Pagina = Math.Max(1, pagina - nPagina),
                Total_Paginas = (int)Math.Ceiling(nEscolas / Tamanho_Pagina)
            };

            vm.Ultima_Pagina = Math.Min(vm.Total_Paginas, pagina + nPagina);
            vm.SearchString = searchString;
            return View(vm);

        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // GET: Escolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolaId,NomeEscola")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

        // GET: Escolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola.FindAsync(id);
            if (escola == null)
            {
                return NotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscolaId,NomeEscola")] Escola escola)
        {
            if (id != escola.EscolaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaExists(escola.EscolaId))
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
            return View(escola);
        }

        // GET: Escolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escola = await _context.Escola.FindAsync(id);
            _context.Escola.Remove(escola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaExists(int id)
        {
            return _context.Escola.Any(e => e.EscolaId == id);
        }
    }
}
