using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas_CP.Models;
using GestaoTarefas_CP.Models.ViewModels;

namespace GestaoTarefas_CP.Views.Funcionarios
{
    public class FuncionariosController : Controller
    {
        public int PageSize = 3;
        private readonly TarefasDbContext _context;

        public FuncionariosController(TarefasDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public IActionResult Index(int page = 1, string searchString = null)
        {
            var Funcionario = from p in _context.Funcionario
                              select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                Funcionario = Funcionario.Where(p => p.Nome.Contains(searchString));
            }

            decimal nFuncionarios = Funcionario.Count();
            int nPage = ((int)nFuncionarios / PageSize);

            if (nFuncionarios % PageSize == 0)
            {
                nPage = 1;
            }

            FuncionarioViewModel vm = new FuncionarioViewModel
            {
                Funcionarios = Funcionario
                .OrderBy(p => p.Nome)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                CurrentPage = page,
                FirstPage = Math.Max(1, page - nPage),
                TotalPages = (int)Math.Ceiling(nFuncionarios / PageSize)
            };

            vm.LastPage = Math.Min(vm.TotalPages, page + nPage);
            vm.StringSearch = searchString;
            return View(vm);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

            // GET: Funcionarios/Create
            public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Numero,Cargo,Morada,Email,Telemovel,NIF")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Numero,Cargo,Morada,Email,Telemovel,NIF")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
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
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionarioId == id);
        }
    }
}
