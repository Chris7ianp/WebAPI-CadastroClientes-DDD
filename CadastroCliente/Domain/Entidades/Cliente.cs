using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Domain.Entidades
{
    public class Cliente
    {
        
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
        public Endereco Endereco { get; set; } = new Endereco();
    }
}
