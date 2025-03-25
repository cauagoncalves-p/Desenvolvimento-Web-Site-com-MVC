using System.ComponentModel.DataAnnotations;

namespace Uc_13_Caua_WebSite.Models
{
    public class Produto
    {
        [Key]
        [Display(Name = "ID do Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Produto")]
        [StringLength(200, ErrorMessage = "O nome do produto não pode exceder 200 caracteres")]
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string? ProdutoNome { get; set; }

        [Display(Name = "Tipo do Produto")]
        [Required(ErrorMessage = "Selecione o tipo do produto")]
        public string? Tipo { get; set; }  

        [Display(Name = "Preço Unitário (R$)")]
        [Required(ErrorMessage = "Informe o preço unitário")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor mínimo é R$0,01")]
        [DataType(DataType.Currency)]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Quantidade")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade mínima é 1")]
        public int Quantidade { get; set; } = 1;

        [Display(Name = "Preço Total (R$)")]
        [DataType(DataType.Currency)]
        public decimal PrecoTotal => PrecoUnitario * (decimal)Quantidade;

        [Display(Name = "ID Fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor? fornecedor { get; set; }
    }
}
