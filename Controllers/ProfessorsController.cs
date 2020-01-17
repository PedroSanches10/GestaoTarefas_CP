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
    public class ProfessorsController : Controller
    {
        public int Tamanho_Pagina = 3;
        private readonly TarefasDbContext _context;

        public ProfessorsController(TarefasDbContext context)
        {
            _context = context;
        }

        // GET: Professors
        public async Task<IActionResult> Index(string searchString = null, int pagina = 1)
        {

            var professor = from s in _context.Professor
                            select s;

            if(!String.IsNullOrEmpty(searchString))
            {
                professor = professor.Where(s => s.Nome.Contains(searchString));
            }

            decimal nProfessores = Professor.Count();
            int nPagina = ((int)nProfessores / Tamanho_Pagina);

            if(nProfessores % Tamanho_Pagina == 0)
            {
                nPagina = 1;
            }

            ProfessorViewModel vm = new ProfessorViewModel
            {
                Professores = professor
                .OrderBy(p => p.Nome)
                .Skip((pagina - 1) * Tamanho_Pagina)
                .Take(Tamanho_Pagina),
                Pagina_Atual = pagina,
                Primeira_Pagina = Math.Max(1, pagina - nPagina),
                Total_Paginas = (int)Math.Ceiling(nProfessores / Tamanho_Pagina)
            };

            vm.Ultima_Pagina = Math.Min(vm.Total_Paginas, pagina + nPagina);
            vm.SearchString = searchString;
            return View(vm);

        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int id)
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
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorId,Nome,Contacto")] Professor professor)
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
