using System.Diagnostics;
using System.Net;
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
    public IActionResult PaginaDeLixas()
    {
        return View();
    }
    public IActionResult PaginaDeRodas()
    {
        return View();
    }
    public IActionResult PaginaDeAcessorios()
    {
        return View();
    }
    public IActionResult PaginaDeToucas() 
    {
        return View();
    }
    public IActionResult PaginaDeTruckes() 
    {
        return View();  
    }
    public IActionResult PaginaContato()
    {
        return View();
    }


    [HttpGet]
    public IActionResult VerProduto(
     string nome, string preco, string precoDesconto,
     string imagem, string parcelamento, string descricao,
     string textoAlternativo, string imagemDemostracao1,
     string imagemDemostracao2, string imagemDemostracao3)
    {
        try
        {
            // Validação básica
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(imagem))
                return RedirectToAction("Error");

            // Decodificação dos parâmetros
            ViewBag.Nome = WebUtility.UrlDecode(nome);
            ViewBag.Preco = WebUtility.UrlDecode(preco);
            ViewBag.PrecoDesconto = WebUtility.UrlDecode(precoDesconto);
            ViewBag.Imagem = WebUtility.UrlDecode(imagem);
            ViewBag.Parcelamento = WebUtility.UrlDecode(parcelamento);
            ViewBag.Descricao = WebUtility.UrlDecode(descricao);
            ViewBag.TextoAlternativo = WebUtility.UrlDecode(textoAlternativo);

            // Imagens de demonstração (com fallback)
            ViewBag.ImagemDemo1 = !string.IsNullOrEmpty(imagemDemostracao1)
                ? WebUtility.UrlDecode(imagemDemostracao1) : ViewBag.Imagem;
            ViewBag.ImagemDemo2 = !string.IsNullOrEmpty(imagemDemostracao2)
                ? WebUtility.UrlDecode(imagemDemostracao2) : ViewBag.Imagem;
            ViewBag.ImagemDemo3 = !string.IsNullOrEmpty(imagemDemostracao3)
                ? WebUtility.UrlDecode(imagemDemostracao3) : ViewBag.Imagem;

            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro no VerProduto");
            return RedirectToAction("Error");
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
