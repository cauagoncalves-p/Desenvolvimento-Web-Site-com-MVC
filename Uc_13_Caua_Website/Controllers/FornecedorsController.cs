using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uc_13_Caua_Website.Data;
using Uc_13_Caua_Website.Models;

namespace Uc_13_Caua_Website.Controllers
{
    public class FornecedorsController : Controller
    {
        private readonly Uc_13_Caua_WebsiteContext _context;

        public FornecedorsController(Uc_13_Caua_WebsiteContext context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedor.ToListAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.FornecedorId == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId,FornecedorName,Email,Celular,CNPJ,EnderecoCompleto,Cidade,Estado,UF,País")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,FornecedorName,Email,Celular,CNPJ,EnderecoCompleto,Cidade,Estado,UF,País")] Fornecedor fornecedor)
        {
            if (id != fornecedor.FornecedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.FornecedorId))
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
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.FornecedorId == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedor.Remove(fornecedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.FornecedorId == id);
        }
    }
}
