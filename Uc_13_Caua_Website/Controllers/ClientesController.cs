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
    public class ClientesController : Controller
    {
        private readonly Uc_13_Caua_WebSiteContext _context;

        public ClientesController(Uc_13_Caua_WebSiteContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,Sobrenome,Email,Celular,CPF,EnderecoCompleto,CEP,Cidade,Estado,UF,Pais")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,Sobrenome,Email,Celular,CPF,EnderecoCompleto,CEP,Cidade,Estado,UF,Pais")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }


        /*==========PESQUISA===========*/
        [HttpGet]
        public async Task<IActionResult> Index(
            string searchString,  // Pesquisa geral (nome, sobrenome, email, CPF, etc.)
            string nome,          // Pesquisa específica por nome
            string cpf,           // Pesquisa específica por CPF
            string cidade,        // Pesquisa específica por cidade
            string estado)        // Pesquisa específica por estado
        {
            IQueryable<Cliente> query = _context.Cliente;

            // Pesquisa geral (case-insensitive)
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(c =>
                    EF.Functions.Like(c.Nome, $"%{searchString}%") ||
                    EF.Functions.Like(c.Sobrenome, $"%{searchString}%") ||
                    EF.Functions.Like(c.Email, $"%{searchString}%") ||
                    EF.Functions.Like(c.CPF, $"%{searchString}%") ||
                    EF.Functions.Like(c.Cidade, $"%{searchString}%") ||
                    EF.Functions.Like(c.Estado, $"%{searchString}%"));
            }

            // Filtros específicos (também case-insensitive)
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(c => EF.Functions.Like(c.Nome, $"%{nome}%"));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(c => EF.Functions.Like(c.CPF, $"%{cpf}%"));
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(c => EF.Functions.Like(c.Cidade, $"%{cidade}%"));
            }

            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(c =>
                    EF.Functions.Like(c.Estado, $"%{estado}%") ||
                    EF.Functions.Like(c.UF, $"%{estado}%"));
            }

            return View(await query.ToListAsync());
        }
        /*==========PESQUISA===========*/
    }
}
