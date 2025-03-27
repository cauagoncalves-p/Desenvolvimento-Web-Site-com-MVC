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
    public class Item_PedidoController : Controller
    {
        private readonly Uc_13_Caua_WebSiteContext _context;

        public Item_PedidoController(Uc_13_Caua_WebSiteContext context)
        {
            _context = context;
        }

        // GET: Item_Pedido
        public async Task<IActionResult> Index()
        {
            var uc_13_Caua_WebSiteContext = _context.Item_Pedido.Include(i => i.Pedido).Include(i => i.Produto);
            return View(await uc_13_Caua_WebSiteContext.ToListAsync());
        }

        // GET: Item_Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_Pedido = await _context.Item_Pedido
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItemPedidoId == id);
            if (item_Pedido == null)
            {
                return NotFound();
            }

            return View(item_Pedido);
        }

        // GET: Item_Pedido/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome");
            CarregarStatus();
            return View();
         
        }
        private void CarregarStatus()
        {
            ViewBag.StatusPedido = new SelectList(new[]
                    {
                new { Value = "Pendente", Text = "Pendente" },
                new { Value = "EmPreparo", Text = "Em Preparo" },
                new { Value = "Pronto", Text = "Pronto para Entrega" },
                new { Value = "EmTransporte", Text = "Em Transporte" },
                new { Value = "Entregue", Text = "Entregue" },
                new { Value = "Cancelado", Text = "Cancelado" },
                new { Value = "Devolvido", Text = "Devolvido" }
            }, "Value", "Text");
        }
        // POST: Item_Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemPedidoId,PedidoId,ProdutoId,Quantidade,PrecoUnitario,Desconto,DataAdicao,Observacoes,Status")] Item_Pedido item_Pedido)
        {
            if (ModelState.IsValid)
            {

                if (item_Pedido.PrecoTotal < 0)
                {
                    ModelState.AddModelError("", "O valor total não pode ser negativo");
                    return View(item_Pedido);
                }

                _context.Add(item_Pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", item_Pedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", item_Pedido.ProdutoId);
            return View(item_Pedido);
        }

        // GET: Item_Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_Pedido = await _context.Item_Pedido.FindAsync(id);
            if (item_Pedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", item_Pedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", item_Pedido.ProdutoId);
            CarregarStatus();
            return View(item_Pedido);
        }

        // POST: Item_Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemPedidoId,PedidoId,ProdutoId,Quantidade,PrecoUnitario,Desconto,DataAdicao,Observacoes,Status")] Item_Pedido item_Pedido)
        {
            if (id != item_Pedido.ItemPedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_Pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_PedidoExists(item_Pedido.ItemPedidoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", item_Pedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", item_Pedido.ProdutoId);
            return View(item_Pedido);
        }

        // GET: Item_Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_Pedido = await _context.Item_Pedido
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItemPedidoId == id);
            if (item_Pedido == null)
            {
                return NotFound();
            }

            return View(item_Pedido);
        }

        // POST: Item_Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item_Pedido = await _context.Item_Pedido.FindAsync(id);
            if (item_Pedido != null)
            {
                _context.Item_Pedido.Remove(item_Pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item_PedidoExists(int id)
        {
            return _context.Item_Pedido.Any(e => e.ItemPedidoId == id);
        }
    }
}
