using System.ComponentModel.DataAnnotations;

namespace Uc_13_Caua_WebSite.Models
{
    public class Fornecedor
    {
        [Key]
        [Display(Name = "ID Fornecedor")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        [Display(Name = "Nome do fornecedor")]
        public string? NomeFornecedor { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O número de celular é obrigatório.")]
        [StringLength(15)]
        [RegularExpression(@"^\(\d{2}\)\s?\d{5}-\d{4}$", ErrorMessage = "Formato: (XX) XXXXX-XXXX")]
        [Display(Name = "Celular")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18)]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "Formato: XX.XXX.XXX/XXXX-XX")]
        [Display(Name = "CNPJ")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O endereço completo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço não pode exceder 200 caracteres.")]
        [Display(Name = "Endereço Completo")]
        public string? EnderecoCompleto { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Formato: XXXXX-XXX")]
        [Display(Name = "CEP")]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100, ErrorMessage = "O nome da cidade não pode exceder 100 caracteres.")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do estado não pode exceder 100 caracteres.")]
        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "A UF é obrigatória.")]
        [StringLength(2, ErrorMessage = "UF deve conter 2 caracteres.")]
        [Display(Name = "UF")]
        public string? UF { get; set; }

        [Required(ErrorMessage = "O Pais é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do Pais não pode exceder 100 caracteres.")]
        [Display(Name = "País")]
        public string? Pais { get; set; }  

        public ICollection<Produto>? Produtos {get; set;}
    }
}
