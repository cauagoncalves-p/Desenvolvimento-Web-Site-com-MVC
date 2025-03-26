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
            var pedidos = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produto)
                .ToListAsync();
            return View(pedidos);
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoId == id);

            return pedido == null ? NotFound() : View(pedido);
        }

        // GET: Pedidoes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ClienteId"] = new SelectList(await _context.Cliente.ToListAsync(), "ClienteId", "ClienteId");
            ViewData["ProdutoId"] = new SelectList(await _context.Produto.ToListAsync(), "ProdutoId", "ProdutoId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,DataPedido,Quantidade,ClienteId,ProdutoId")] Pedido pedido)
        {
            var produto = await _context.Produto.FindAsync(pedido.ProdutoId);

            // Validação de estoque
            if (produto == null || pedido.Quantidade > produto.Quantidade)
            {
                ModelState.AddModelError(nameof(Pedido.Quantidade),
                    $"Estoque insuficiente. Máximo disponível: {produto?.Quantidade ?? 0}");
            }

            if (ModelState.IsValid)
            {
                // Calcula o preço total
                pedido.Preco = pedido.Quantidade * produto.PrecoUnitario;
                pedido.DataPedido = DateTime.Now;

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarrega os dados se houver erro
            ViewData["ClienteId"] = new SelectList(await _context.Cliente.ToListAsync(), "ClienteId", "ClienteId", pedido.ClienteId);
            ViewData["ProdutoId"] = new SelectList(await _context.Produto.ToListAsync(), "ProdutoId", "ProdutoId", pedido.ProdutoId);
            return View(pedido);
        }

        [HttpGet]
        public async Task<JsonResult> GetProdutoInfo(int produtoId)
        {
            var produto = await _context.Produto
                .Where(p => p.ProdutoId == produtoId)
                .Select(p => new {
                    precoUnitario = p.PrecoUnitario,
                    estoque = p.Quantidade
                })
                .FirstOrDefaultAsync();

            return Json(produto ?? new { precoUnitario = 0m, estoque = 0 });
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", pedido.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", pedido.ProdutoId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,DataPedido,Quantidade,Preco,ClienteId,ProdutoId")] Pedido pedido)
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", pedido.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", pedido.ProdutoId);
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
    }
}
