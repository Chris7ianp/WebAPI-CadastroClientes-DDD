using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Application.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public EnderecoDto Endereco { get; set; } = new EnderecoDto();
    }
}
