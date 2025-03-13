# Sales API - .NET 8

API para gerenciamento de vendas, desenvolvida em **.NET 8**, com autenticação JWT, uso do PostgreSQL e testes automatizados.

---

## 📌 1. Requisitos

Antes de executar o projeto, certifique-se de que possui instalado:

✅ [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)  
✅ [PostgreSQL](https://www.postgresql.org/download/)  
✅ [Docker](https://www.docker.com/get-started/) *(Opcional, caso queira rodar o PostgreSQL via container)*  
✅ [Git](https://git-scm.com/downloads)  

---

## 📌 2. Configuração do Banco de Dados

### 1️⃣ Criar a database no PostgreSQL

Abra o terminal do PostgreSQL e execute:

```sql
CREATE DATABASE salesdb;
```

### 2️⃣ Atualizar o arquivo `appsettings.json`

No arquivo `appsettings.json`, altere a string de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=salesdb;Username=seu_usuario;Password=sua_senha"
}
```
**Substitua `seu_usuario` e `sua_senha` pelos seus dados do PostgreSQL.**  

### 3️⃣ Criar as tabelas

Execute o seguinte comando para aplicar as migrações do Entity Framework Core:

```sh
dotnet ef database update
```

Caso o comando acima não funcione, execute:

```sh
dotnet tool install --global dotnet-ef
dotnet ef database update
```

---

## 📌 3. Executando o Projeto

Para rodar a API localmente, siga estes passos:

### 1️⃣ Clone o repositório

```sh
git clone https://github.com/Laionluis/TesteAmbev.git
cd TesteAmbev
```

### 2️⃣ Restaurar as dependências

```sh
dotnet restore
```

### 3️⃣ Executar a aplicação

```sh
dotnet run
```

A API estará rodando em **http://localhost:5000** ou **https://localhost:5001**.

---

## 📌 4. Testando a API

### 📝 Teste no Swagger

Acesse no navegador:

```
https://localhost:5001/swagger
```

### 📂 Autenticação JWT

1. Faça login na API:  
   **Endpoint:** `POST /api/auth/login`  
   **Corpo da requisição:**
   ```json
   {
     "username": "admin",
     "password": "password"
   }
   ```
2. Copie o token JWT da resposta.  
3. No Swagger, clique no botão **"Authorize"** e cole o token:  
   ```
   Bearer SEU_TOKEN
   ```
4. Agora você pode testar rotas protegidas como `GET /api/sales`.

---

## 📌 5. Rodando Testes Automatizados

Para rodar os testes unitários, execute:

```sh
dotnet test
```

Se precisar de mais detalhes sobre erros nos testes, execute:

```sh
dotnet test --diag log.txt
```

---

## 📌 6. Rodando PostgreSQL via Docker (Opcional)

Caso prefira rodar o PostgreSQL via **Docker**, execute:

```sh
docker run --name salesdb -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e POSTGRES_DB=salesdb -p 5432:5432 -d postgres
```

Isso cria um banco PostgreSQL rodando no **localhost:5432**.  
Basta atualizar a string de conexão no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=salesdb;Username=admin;Password=admin"
}
```

Para parar o container:

```sh
docker stop salesdb
```

Para iniciar novamente:

```sh
docker start salesdb
```

---

## 📌 7. Contato

Se precisar de ajuda, entre em contato via 📧 [ferreiralaionl@gmail.com](mailto:ferreiralaionl@gmail.com).

---

🚀 Agora sua API está pronta para ser testada! Se houver dúvidas ou sugestões, me avise. 🎯🔥

