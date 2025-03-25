using System.ComponentModel.DataAnnotations;

namespace Uc_13_Caua_WebSite.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "ID Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Sobrenome")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O numero de celular é obrigatório.")]
        [StringLength(15)]
        [RegularExpression(@"^\(\d{2}\)\s?\d{5}-\d{4}$", ErrorMessage = "Número de celular inválido.")]
        [Display(Name = "Numero de celular")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")]
        [Display(Name = "CPF")]
        public string? CPF { get; set;}

        [Required(ErrorMessage = "O Endereço Completo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço completo não pode exceder 200 caracteres.")]
        [Display(Name = "Endereço Completo")]
        public string? EnderecoCompleto { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido")]
        [Display(Name = "CEP")]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "O nome da Cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da cidade não pode exceder 100 caracteres.")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O nome do Estado é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do estado não pode exceder 100 caracteres.")]
        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "O UF deve ter no máximo 2 caracteres.")]
        [Display(Name = "UF")]
        public string? UF { get; set; }

        [Required(ErrorMessage = "O nome do Pais é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do Pais não pode exceder 100 caracteres.")]
        [Display(Name = "Pais")]
        public string? Pais { get; set; }  
    }
}
