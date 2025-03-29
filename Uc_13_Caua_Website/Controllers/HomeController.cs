using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Uc_13_Caua_WebSite.Models;

namespace Uc_13_Caua_WebSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    } 
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Cadastro()
    {
        return View();
    }
    public IActionResult PaginaSkatesMontados()
    {
        return View();
    }
    public IActionResult FinalizarCompra()
    {
        return View();
    } 
    public IActionResult Produtos()
    {
        return View();
    }
    public IActionResult VerProduto()
    {
        return View();
    }
    public IActionResult PaginaCamisetas() {
        return View();
    }

    public IActionResult PaginaDeShapes() 
    {
        return View();
    }
    public IActionResult PaginaDeTenis()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
