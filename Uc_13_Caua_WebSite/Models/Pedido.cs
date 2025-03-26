using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uc_13_Caua_WebSite.Models
{
    public class Pedido
    {
        [Key]
        [Display(Name = "ID Pedido")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória")]
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.DateTime)]
        public DateTime DataPedido { get; set; } 

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1")]
        public int Quantidade {get; set;}

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco {get; set;}

        [NotMapped]
        public decimal PrecoUnitario => Produto?.PrecoUnitario ?? 0;
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Selecione o ID do cliente")]
        [Display(Name = "ID Cliente")]
        public Cliente? Cliente { get; set; }

        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Selecione o ID do produto")]
        [Display(Name = "ID Produto")]
        public Produto? Produto { get; set; }
    }
}
