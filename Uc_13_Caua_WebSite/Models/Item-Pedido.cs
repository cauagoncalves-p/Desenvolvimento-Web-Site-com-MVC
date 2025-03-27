using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uc_13_Caua_WebSite.Models
{
    public class Item_Pedido
    {
        [Key]
        [Display(Name = "ID do Item")]
        public int ItemPedidoId { get; set; }

        // Relacionamento com Pedido
        [Required(ErrorMessage = "O pedido é obrigatório")]
        [Display(Name = "ID do Pedido")]
        public int PedidoId { get; set; }

        [Display(Name = "Pedido")]
        public Pedido? Pedido { get; set; }

        // Relacionamento com Produto
        [Required(ErrorMessage = "O produto é obrigatório")]
        [Display(Name = "Nome do produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Produto")]
        public Produto? Produto { get; set; }

        // Dados do Item
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade mínima é 1")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; } = 1;

        [Required(ErrorMessage = "O preço unitário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor mínimo é R$0,01")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço Unitário (R$)")]
        public decimal PrecoUnitario { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O desconto não pode ser negativo")]
        [DataType(DataType.Currency)]
        [Display(Name = "Desconto (R$)")]
        public decimal Desconto { get; set; } = 0;

        [DataType(DataType.Currency)]
        [Display(Name = "Preço Total (R$)")]
        [NotMapped]
        public decimal PrecoTotal => (PrecoUnitario * Quantidade) - Desconto;

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Adição")]
        public DateTime DataAdicao { get; set; } = DateTime.Now;

        [Display(Name = "Observações")]
        [StringLength(500, ErrorMessage = "As observações não podem exceder 500 caracteres")]
        public string? Observacoes { get; set; }

        [Display(Name = "Status do Item")]
        public string Status { get; set; } = "Pendente"; // Pendente, Processando, Entregue, Cancelado

    }
}
