namespace Uc_13_Caua_WebSite.Models
{
    public class VerProduto
    {
        // Models/Produto.cs
    
            public int Id { get; set; }  // Adicionei ID para melhor controle
            public string? Titulo { get; set; }
            public string? Classificacao { get; set; }
            public decimal? Preco { get; set; }  // Mudei para decimal para cálculos
            public decimal? PrecoDesconto { get; set; }
            public string? ImagemUrl { get; set; }  // Nome mais descritivo
            public string? Parcelamento { get; set; }
            public string? Descricao { get; set; }
            public string? TextoAlternativo { get; set; }

            // Coleção para imagens (mais organizado)
            public List<string> ImagensDemonstracao { get; set; } = new List<string>();
       
    }
}
