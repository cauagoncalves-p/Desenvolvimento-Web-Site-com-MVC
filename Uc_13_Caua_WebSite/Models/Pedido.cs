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

        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public virtual Cliente? Cliente { get; set; }

        [Required]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        [Display(Name = "Produto")]
        public virtual Produto? Produto { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória")]
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.DateTime)]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }
}
