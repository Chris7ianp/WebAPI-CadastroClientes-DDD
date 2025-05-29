using AutoMapper;
using CadastroCliente.Application.DTOs;
using CadastroCliente.Domain.Entidades;

namespace CadastroCliente.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
    }
}
