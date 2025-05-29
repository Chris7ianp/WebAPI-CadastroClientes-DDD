
# 📋 Cadastro de Clientes - Web API (ASP.NET Core + DDD + EF Core In-Memory)

Este projeto é uma Web API desenvolvida com ASP.NET Core, estruturada segundo os princípios do Domain-Driven Design (DDD). Ele permite o cadastro de clientes e seus respectivos endereços, utilizando Entity Framework Core com banco de dados em memória.


## ✅ Funcionalidades

- Listar todos os clientes (`GET /clientes`)
- Obter um cliente por ID (`GET /clientes/{id}`)
- Criar um novo cliente (`POST /clientes`)
- Atualizar um cliente existente (`PUT /clientes/{id}`)
- Deletar um cliente (`DELETE /clientes/{id}`)


## 🧱 Estrutura de Pastas
- /CadastroCliente
- ├── API/ # Interface da aplicação (Controllers)
- │ └── Controllers/
- │ └── ClienteController.cs
- │
- ├── Application/ # Camada de aplicação (DTOs, validações, serviços)
- │ └── DTOs/
- │ └── ClienteDto.cs
- │ └── EnderecoDto.cs
- │
- ├── Domain/ # Camada de domínio (regras de negócio puras)
- │ ├── Entities/
- │ │ └── Cliente.cs
- │ └── Interfaces/
- │ └── IClienteRepository.cs
- │
- ├── Infrastructure/ # Acesso a dados e persistência
- │ ├── Data/
- │ │ └── AppDbContext.cs
- │ └── Repositories/
- │ └── ClienteRepository.cs
- │
- ├── Mapping/ # Mapeamento entre DTOs e entidades (AutoMapper)
- │ └── AutoMapperProfile.cs
- │
- ├── Services/ # Serviços de aplicação (lógica de negócio)
- │ └── ClienteService.cs
- │
- ├── Program.cs # Configuração e inicialização da aplicação
- └── README.md # Documentação do projeto

## 🛠️ Tecnologias Utilizadas

- [.NET 9.0](https://dotnet.microsoft.com/)
- **ASP.NET Core Web API**
- **Entity Framework Core** (com banco In-Memory)
- **AutoMapper** (para conversão entre DTOs e entidades)
- **Swagger / OpenAPI** (documentação e testes)

## 📦 Instalação e Execução

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd CadastroCliente

2. **Restaure os pacotes e execute o projeto**
    ```bash
    dotnet restore
    dotnet run

3. **Acesse o Swagger**
    ```bash
    O Swagger será aberto automaticamente ou estará disponível em: http://localhost:5007

    dotnet restore
    dotnet run
## 🔁 Exemplos de Requisições
POST /clientes

```json
{
  "nome": "Maria Silva",
  "email": "maria@email.com",
  "telefone": "11999999999",
  "endereco": {
    "rua": "Rua A",
    "numero": "123",
    "cidade": "São Paulo",
    "estado": "SP",
    "cep": "01234-567"
  }
}
```
Resposta esperada (201 Created)
```json
{
  "id": "guid-gerado",
  "nome": "Maria Silva",
  "email": "maria@email.com",
  "telefone": "11999999999",
  "endereco": {
    "rua": "Rua A",
    "numero": "123",
    "cidade": "São Paulo",
    "estado": "SP",
    "cep": "01234-567"
  }
}
```

## 🧪 Testes
Este projeto utiliza um banco de dados In-Memory, o que facilita testes locais sem necessidade de configuração de um banco real.

## 🔒 Validações

- Nome e Email são obrigatórios.

- Email deve ser único e válido.

- Endereço completo obrigatório: Rua, Número, Cidade, Estado e CEP.