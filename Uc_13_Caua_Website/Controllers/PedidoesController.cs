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
    public class PedidoesController : Controller
    {
        private readonly Uc_13_Caua_WebSiteContext _context;

        public PedidoesController(Uc_13_Caua_WebSiteContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var uc_13_Caua_WebSiteContext = _context.Pedido.Include(p => p.Cliente).Include(p => p.Produto);
            return View(await uc_13_Caua_WebSiteContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,Quantidade,ClienteId,ProdutoId,Preco,DataPedido")] Pedido pedido)
        {
            // 1. Primeiro carrega as listas (para caso precise retornar a view)
            ViewData["ClienteId"] = new SelectList(await _context.Cliente.ToListAsync(), "ClienteId", "Nome", pedido.ClienteId);
            ViewData["ProdutoId"] = new SelectList(await _context.Produto.ToListAsync(), "ProdutoId", "Nome", pedido.ProdutoId);

            // 2. Validação básica do ModelState
            if (!ModelState.IsValid)
            {
                return View(pedido);
            }

            // 3. Busca o produto (assíncrono)
            var produto = await _context.Produto.FindAsync(pedido.ProdutoId);

            // 4. Validações de negócio ANTES de salvar
            var erroValidacao = pedido.ValidarEstoque(produto);
            if (erroValidacao != null)
            {
                ModelState.AddModelError("", erroValidacao);
                return View(pedido);
            }

            // 5. Cálculos automáticos
            pedido.CalcularPrecoTotal(produto);
            pedido.DataPedido = DateTime.Now;

            // 6. Tentativa de salvamento
            try
            {
                _context.Pedido.Add(pedido);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Pedido cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", $"Erro no banco de dados: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro inesperado: {ex.Message}");
            }

            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", pedido.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", pedido.ProdutoId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,Quantidade,ClienteId,ProdutoId,Preco,DataPedido")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", pedido.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", pedido.ProdutoId);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedido.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.PedidoId == id);
        }


        /*======PESQUISAR=======*/
        [HttpGet]
        public async Task<IActionResult> Index(
    string searchString,      // Pesquisa geral
    int? clienteId,          // Filtro por ID do cliente
    int? produtoId,          // Filtro por ID do produto
    int? quantidadeMinima,   // Filtro por quantidade mínima
    DateTime? dataPedido)    // Filtro por data do pedido
        {
            IQueryable<Pedido> query = _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produto);

            // Pesquisa geral
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p =>
                    p.Cliente.Nome.Contains(searchString) ||
                    p.Produto.ProdutoNome.Contains(searchString));
            }

            // Filtro por cliente
            if (clienteId.HasValue)
            {
                query = query.Where(p => p.ClienteId == clienteId.Value);
            }

            // Filtro por produto
            if (produtoId.HasValue)
            {
                query = query.Where(p => p.ProdutoId == produtoId.Value);
            }

            // Filtro por quantidade mínima
            if (quantidadeMinima.HasValue)
            {
                query = query.Where(p => p.Quantidade >= quantidadeMinima.Value);
            }

            // Filtro por data do pedido
            if (dataPedido.HasValue)
            {
                query = query.Where(p => p.DataPedido.Date == dataPedido.Value.Date);
            }

            return View(await query.ToListAsync());
        }
        /*======PESQUISAR=======*/
    }
}
