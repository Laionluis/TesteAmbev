Sales API - .NET 8
API para gerenciamento de vendas, desenvolvida em .NET 8, com autenticação JWT, uso do PostgreSQL e testes automatizados.

1. Requisitos
Antes de executar o projeto, certifique-se de que possui instalado:

✅ .NET 8 SDK
✅ PostgreSQL
✅ Docker (Opcional, caso queira rodar o PostgreSQL via container)
✅ Git

2. Configuração do Banco de Dados
1️⃣ Criar a database no PostgreSQL Abra o terminal do PostgreSQL e execute:

CREATE DATABASE salesdb;

Atualizar o arquivo appsettings.json No arquivo appsettings.json, altere a string de conexão:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=salesdb;Username=seu_usuario;Password=sua_senha"
}

Substitua seu_usuario e sua_senha pelos seus dados do PostgreSQL

Criar as tabelas Execute o seguinte comando para aplicar as migrações do Entity Framework Core:
dotnet ef database update

Caso o comando acima não funcione, execute:
dotnet tool install --global dotnet-ef
dotnet ef database update

Executando o Projeto

Para rodar a API localmente, siga estes passos:

1️⃣ Clone o repositório
git clone https://github.com/Laionluis/TesteAmbev.git
cd seu-repositorio

Restaurar as dependências
dotnet restore

Testando a API
Teste no Swagger
Acesse no navegador:
https://localhost:5001/swagger
Autenticação JWT
Faça login na API:
Endpoint: POST /api/auth/login
Corpo da requisição:
{
  "username": "admin",
  "password": "password"
}
Copie o token JWT da resposta.
No Swagger, clique no botão "Authorize" e cole o token
Agora você pode testar rotas protegidas como GET /api/sales


Contato
Se precisar de ajuda, entre em contato via ferreiralaionl@gmail.com
