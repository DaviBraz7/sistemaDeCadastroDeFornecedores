using System.ComponentModel.DataAnnotations;

namespace sistemaDeCadastroDeFornecedores.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Fornecedor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ do Fornecedor")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "Selecione a Especialidade do Fornecedor")]
        public string Especialidade { get; set; }
    }
}
