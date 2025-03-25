using System.ComponentModel.DataAnnotations;

namespace Uc_13_Caua_WebSite.Models
{
    public class Produto
    {
        [Key]
        [Display(Name = "ID do Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Produto")]
        [StringLength(200, ErrorMessage = "Produto não pode ter mais de 200 caracteres")]
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string? ProdutoNome { get; set;}

        [Display(Name = "Tipo do produto")]
        [Required(ErrorMessage = "Selecione o tipo do produto")]
        public string? Tipo { get; set; }
    }
}
