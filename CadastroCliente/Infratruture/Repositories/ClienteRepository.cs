using CadastroCliente.Domain.Entidades;
using CadastroCliente.Domain.Interfaces;
using CadastroCliente.Infratruture.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infratruture.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) => _context = context;

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
        public void Atualizar(Cliente cliente)
        {
            var local = _context.Clientes.Local
        .FirstOrDefault(entry => entry.Id == cliente.Id);

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            //_context.Clientes.Update(cliente);
            //_context.SaveChanges();
        }
        public Cliente? ObterPorId(Guid id) => _context.Clientes.Find(id);

        public IEnumerable<Cliente> ObterTodos() => _context.Clientes.ToList();

        public void Remover(Guid id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
        public bool EmailExiste(string email, Guid? idIgnorar = null) => _context.Clientes.Any(c => c.Email == email && c.Id != idIgnorar);        
    }
}