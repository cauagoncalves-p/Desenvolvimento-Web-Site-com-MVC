using System.ComponentModel.DataAnnotations;

namespace Uc_13_Caua_WebSite.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [StringLength(100)]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O numero de celular é obrigatório.")]
        [StringLength(15)]
        [RegularExpression(@"^\(\d{2}\)\s?\d{5}-\d{4}$", ErrorMessage = "Número de celular inválido.")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(18)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")]
        public string? CPF { get; set;}

        [Required(ErrorMessage = "O Endereço Completo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço completo não pode exceder 200 caracteres.")]
        public string? EnderecoCompleto { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido")]  
        public string? CEP { get; set; }

        [Required(ErrorMessage = "O nome da Cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da cidade não pode exceder 100 caracteres.")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O nome do Estado é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do estado não pode exceder 100 caracteres.")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "O UF deve ter no máximo 2 caracteres.")]
        public string? UF { get; set; }

        [Required(ErrorMessage = "O nome do País é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do país não pode exceder 100 caracteres.")]
        public string? País { get; set; }  
    }
}
