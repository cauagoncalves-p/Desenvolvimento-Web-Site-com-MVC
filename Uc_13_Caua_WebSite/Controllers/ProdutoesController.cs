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
    public class ProdutoesController : Controller
    {
        private readonly Uc_13_Caua_WebSiteContext _context;

        public ProdutoesController(Uc_13_Caua_WebSiteContext context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            var uc_13_Caua_WebSiteContext = _context.Produto.Include(p => p.fornecedor);
            return View(await uc_13_Caua_WebSiteContext.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.fornecedor)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId");
            CarregarTiposProdutos();
            return View();
        }

        private void CarregarTiposProdutos() 
        {
            ViewBag.TiposProduto = new SelectList(new List<string>
            {
                "Shape",
                "Rodas",
                "Trucks",
                "Rolamentos",
                "Lixas",
                "Parafusos/Hardware",
                "Amortecedores"
            });
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,ProdutoNome,Tipo,PrecoUnitario,Quantidade,FornecedorId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
               

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId", produto.FornecedorId);
            CarregarTiposProdutos();
            return View(produto);
            // Se houver erro, recarrega os dados necessários
 
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId","FornecedorId",  produto.FornecedorId);
            CarregarTiposProdutos();
            return View(produto);
            
        }


        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,ProdutoNome,Tipo,PrecoUnitario,Quantidade,DataCadastro,FornecedorId")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
              
                return NotFound();
                
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId", produto.FornecedorId);
            // Recarrega os dados se houver erro
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.fornecedor)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.ProdutoId == id);
        }

        /*=======PESQUISAR========*/
        [HttpGet]
            public async Task<IActionResult> Index(
        string searchString,      // Pesquisa geral
        string nomeProduto,       // Filtro por nome
        string tipoProduto,       // Filtro por tipo
        decimal? precoMinimo,     // Filtro por preço mínimo
        int? fornecedorId)        // Filtro por fornecedor
            {
                IQueryable<Produto> query = _context.Produto;

                // Pesquisa geral
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(p =>
                        p.ProdutoNome.Contains(searchString) ||
                        p.Tipo.Contains(searchString) ||
                        p.fornecedor.NomeFornecedor.Contains(searchString));
                }

                // Filtro por nome do produto
                if (!string.IsNullOrEmpty(nomeProduto))
                {
                    query = query.Where(p => p.ProdutoNome.Contains(nomeProduto));
                }

                // Filtro por tipo de produto
                if (!string.IsNullOrEmpty(tipoProduto))
                {
                    query = query.Where(p => p.Tipo.Contains(tipoProduto));
                }

                // Filtro por preço mínimo
                if (precoMinimo.HasValue)
                {
                    query = query.Where(p => p.PrecoUnitario >= precoMinimo.Value);
                }

                // Filtro por fornecedor
                if (fornecedorId.HasValue)
                {
                    query = query.Where(p => p.FornecedorId == fornecedorId.Value);
                }

                return View(await query.ToListAsync());
            /*=======PESQUISAR========*/
        }
    }
}
