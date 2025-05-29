using AutoMapper;
using CadastroCliente.Application.DTOs;
using CadastroCliente.Domain.Entidades;
using CadastroCliente.Domain.Interfaces;


namespace CadastroCliente.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IMapper _mapper;


        public ClienteService(IClienteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ClienteDto> ObterTodos() =>
            _repo.ObterTodos().Select(c => _mapper.Map<ClienteDto>(c));

        public ClienteDto? ObterPorId(Guid id)=>
            _mapper.Map<ClienteDto>(_repo.ObterPorId(id));

        public (ClienteDto? clienteCriado, string? erro) Criar(ClienteDto dto)
        {
            
            if (_repo.EmailExiste(dto.Email))
            {
                return (null, "Email já cadastrado.");
            }

            var cliente = _mapper.Map<Cliente>(dto);
            cliente.Id = Guid.NewGuid(); 

            _repo.Adicionar(cliente); 

            var clienteDto = _mapper.Map<ClienteDto>(cliente); 

            return (clienteDto, null);
        }

        public string? Atualizar(Guid id, ClienteDto dto)
        {
            var existente = _repo.ObterPorId(id);
            if(existente == null)
            {
                return "Cliente não encontrado.";
            }
            if(_repo.EmailExiste(dto.Email, id))
            {
                return "Email já cadastrado.";
            }

            var cliente = _mapper.Map<Cliente>(dto);
            cliente.Id = id;

            _repo.Atualizar(cliente);

            return null;            
        }

        public bool Remover(Guid id)
        {
            var existente = _repo.ObterPorId(id);
            
            if (existente == null)
            {
                return false;
            }

            _repo.Remover(id);

            return true;
        }
    }
}
