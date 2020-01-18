using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas_CP.Models;
using GestaoTarefas_CP.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GestaoTarefas_CP.Controllers
{
    [Authorize(Policy = "CanManageGestaoTarefas_CP")]
    [Authorize(Roles = "cari")]

    public class ProfessorsController : Controller
    {
        public int Tamanho_Pagina = 3;
        private readonly TarefasDbContext _context;

        public ProfessorsController(TarefasDbContext context)
        {
            _context = context;
        }

        // GET: Professors
        public IActionResult Index(int pagina = 1, string searchString = null)
        {

            var Professor = from s in _context.Professor
                            select s;

            if(!String.IsNullOrEmpty(searchString))
            {
                Professor = Professor.Where(s => s.Nome.Contains(searchString));
            }

            decimal nProfessors = Professor.Count();
            int nPagina = ((int)nProfessors / Tamanho_Pagina);

            if(nProfessors % Tamanho_Pagina == 0)
            {
                nPagina = 1;
            }

            ProfessorViewModel vm = new ProfessorViewModel
            {
                Professors = Professor
                .OrderBy(s => s.Nome)
                .Skip((pagina - 1) * Tamanho_Pagina)
                .Take(Tamanho_Pagina),
                Pagina_Atual = pagina,
                Primeira_Pagina = Math.Max(1, pagina - nPagina),
                Total_Paginas = (int)Math.Ceiling(nProfessors / Tamanho_Pagina)
            };

            vm.Ultima_Pagina = Math.Min(vm.Total_Paginas, pagina + nPagina);
            vm.SearchString = searchString;
            return View(vm);

        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
     
         
            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorId,Nome,Telemovel,Email,Gabinete,Disciplina")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorId,Nome,Telemovel,Email,Gabinete,Disciplina")] Professor professor)
        {
            if (id != professor.ProfessorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ProfessorId))
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
            return View(professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.ProfessorId == id);
        }
    }
}
