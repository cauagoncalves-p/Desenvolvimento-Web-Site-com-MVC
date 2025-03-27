using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Uc_13_Caua_WebSite.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Preço Total")]
        public decimal Preco { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data do Pedido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataPedido { get; set; }

       
        [Display(Name = "Cliente")]
        public Cliente? Cliente { get; set; }

        [Display(Name = "Produto")]
        public Produto? Produto { get; set; }

        // Método para validar estoque (pode ser chamado no controller)
        public string ValidarEstoque(Produto produto)
        {
            if (produto == null)
                return "Produto não encontrado";

            if (Quantidade <= 0)
                return "Quantidade deve ser maior que zero";

            if (Quantidade > produto.Quantidade)
                return $"Estoque insuficiente. Disponível: {produto.Quantidade}";

            return null; // Retorna null se não houver erros
        }

        // Método para calcular o preço total
        public void CalcularPrecoTotal(Produto produto)
        {
            if (produto != null && Quantidade > 0)
            {
                Preco = Quantidade * produto.PrecoUnitario;
            }
        }

        public ICollection<Item_Pedido>? Item_Pedidos { get; set; }
    }
}
