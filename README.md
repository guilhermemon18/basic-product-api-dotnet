# API PRODUTOS

**Introdução**

Esta API fornece funcionalidades para gerenciar produtos em um sistema. Ela é construída com ASP.NET Core e utiliza a própria memória RAM como um banco de dados.

**Como usar a API**

Para utilizar esta API, você precisará de um cliente HTTP como Postman ou Insomnia para fazer as requisições.

**Endpoints**

| Método | URL | Parâmetros | Resposta | Descrição |
|---|---|---|---|---|
| POST | /saveproduct | { "code": "1", "name": "HDD" } | - | Cria um novo produto |
| GET | /getproduct/{code}| id (int) | JSON (product) | Retorna um produto específico |
| PUT | /editproduct | { "code": "1", "name": "Memória RAM" } | -| Atualiza um produto existente |
| DELETE | /deleteproduct/{code} | id (int) | - | Deleta um produto |
