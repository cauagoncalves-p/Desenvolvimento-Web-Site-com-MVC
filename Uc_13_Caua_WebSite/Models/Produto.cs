using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public decimal PrecoTotal => PrecoUnitario * Quantidade;

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public int FornecedorId { get; set; }
        [Display(Name = "ID Fornecedor")]
        public Fornecedor? fornecedor { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }   
    }
}
