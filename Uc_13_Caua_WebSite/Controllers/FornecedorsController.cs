using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uc_13_Caua_WebSite.Data;
using Uc_13_Caua_WebSite.Models;

namespace Uc_13_Caua_WebSite.Controllers
{
    public class FornecedorsController : Controller
    {
        private readonly Uc_13_Caua_WebSiteContext _context;

        public FornecedorsController(Uc_13_Caua_WebSiteContext context)
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
            CarregarEstados();
            return View();
        }


        private void CarregarEstados()
        {
            ViewBag.Estados = new SelectList(new[]
            {
                new { Value = "AC", Text = "Acre" },
                new { Value = "AL", Text = "Alagoas" },
                new { Value = "AP", Text = "Amapá" },
                new { Value = "AM", Text = "Amazonas" },
                new { Value = "BA", Text = "Bahia" },
                new { Value = "CE", Text = "Ceará" },
                new { Value = "DF", Text = "Distrito Federal" },
                new { Value = "ES", Text = "Espírito Santo" },
                new { Value = "GO", Text = "Goiás" },
                new { Value = "MA", Text = "Maranhão" },
                new { Value = "MT", Text = "Mato Grosso" },
                new { Value = "MS", Text = "Mato Grosso do Sul" },
                new { Value = "MG", Text = "Minas Gerais" },
                new { Value = "PA", Text = "Pará" },
                new { Value = "PB", Text = "Paraíba" },
                new { Value = "PR", Text = "Paraná" },
                new { Value = "PE", Text = "Pernambuco" },
                new { Value = "PI", Text = "Piauí" },
                new { Value = "RJ", Text = "Rio de Janeiro" },
                new { Value = "RN", Text = "Rio Grande do Norte" },
                new { Value = "RS", Text = "Rio Grande do Sul" },
                new { Value = "RO", Text = "Rondônia" },
                new { Value = "RR", Text = "Roraima" },
                new { Value = "SC", Text = "Santa Catarina" },
                new { Value = "SP", Text = "São Paulo" },
                new { Value = "SE", Text = "Sergipe" },
                new { Value = "TO", Text = "Tocantins" }
            }, "Value", "Text");
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId,NomeFornecedor,Email,Celular,CNPJ,EnderecoCompleto,CEP,Cidade,Estado,UF,Pais")] Fornecedor fornecedor)
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
            CarregarEstados();
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,NomeFornecedor,Email,Celular,CNPJ,EnderecoCompleto,CEP,Cidade,Estado,UF,Pais")] Fornecedor fornecedor)
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
            CarregarEstados();
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

        /*========PESQUISA=========*/
        [HttpGet]
        public async Task<IActionResult> Index(
       string searchString,  // Pesquisa geral
       string nome,          // Filtro por nome
       string cnpj,          // Filtro por CNPJ
       string cidade,        // Filtro por cidade
       string uf)            // Filtro por UF
        {
            IQueryable<Fornecedor> query = _context.Fornecedor;

            // Pesquisa geral
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(f =>
                    f.NomeFornecedor.Contains(searchString) ||
                    f.CNPJ.Contains(searchString) ||
                    f.Cidade.Contains(searchString) ||
                    f.Email.Contains(searchString));
            }

            // Filtro por nome
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(f => f.NomeFornecedor.Contains(nome));
            }

            // Filtro por CNPJ (com ou sem formatação)
            if (!string.IsNullOrEmpty(cnpj))
            {
                string cnpjNumeros = new string(cnpj.Where(char.IsDigit).ToArray());
                query = query.Where(f => f.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "").Contains(cnpjNumeros));
            }

            // Filtro por cidade
            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(f => f.Cidade.Contains(cidade));
            }

            // Filtro por UF
            if (!string.IsNullOrEmpty(uf))
            {
                query = query.Where(f => f.UF == uf);
            }

            return View(await query.ToListAsync());
        }
        /*========PESQUISA=========*/

    }
}
