# Desafio ASP.NET – API de Tasks

Projeto desenvolvido como parte de um desafio do curso de **ASP.NET**, com o objetivo de praticar arquitetura em camadas, casos de uso e API REST.

## Como rodar o projeto

### Pré-requisitos
- .NET SDK instalado (versão compatível com o projeto)

### Passos para execução

1. Clone o repositório:
   ```bash
   git clone [<url-do-repositorio>](https://github.com/Giovanni-Gomes/CSharp-DesafioPratico3)
2. Abra a solução do projeto:
3. Execute o build:
   ```bash
   dotnet build
4. Execute a aplicação (projeto Api):
   ```bash
   dotnet run --project Task.Api
5. Teste as rotas disponiveis no Swagger:
   ```bash
   https://localhost:{porta}/swagger

#### Observações

- O projeto não utiliza banco de dados

- Os dados são armazenados em memória enquanto a aplicação estiver em execução

- Projeto com finalidade educacional
