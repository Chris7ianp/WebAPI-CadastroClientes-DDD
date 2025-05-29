using CadastroCliente.Domain.Entidades;

namespace CadastroCliente.Domain.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterTodos();
        Cliente? ObterPorId(Guid id);
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(Guid id);
        bool EmailExiste(string email, Guid? idIgnorar = null);        
    }
}
