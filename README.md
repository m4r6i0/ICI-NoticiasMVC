
<div align="center">
  <h1>📰 ICI Notícias MVC</h1>
  <p>Aplicação ASP.NET Core MVC para gestão de notícias com associação de usuários e tags.</p>

  <img src="https://img.shields.io/badge/.NET-8.0-blue?logo=.net" />
  <img src="https://img.shields.io/badge/EntityFrameworkCore-8.0-green?logo=dotnet" />
  <img src="https://img.shields.io/badge/SQLite-3.41-blue?logo=sqlite" />
  <img src="https://img.shields.io/badge/AutoMapper-12.0-orange?logo=automapper" />
  <img src="https://img.shields.io/badge/Select2-JS-blueviolet?logo=javascript" />
</div>

---

## 🧾 Descrição

Este projeto é uma aplicação web desenvolvida em ASP.NET Core MVC com foco em boas práticas de arquitetura, organização em camadas e uso de DTOs e AutoMapper para separação de responsabilidades.

O sistema permite:

- CRUD de Notícias
- CRUD de Tags
- CRUD de Usuários
- Associação de múltiplas Tags a uma Notícia
- Seleção de autor da Notícia via Dropdown
- Interface rica com uso de JavaScript e Select2

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core MVC 8.0
- Entity Framework Core + SQLite
- AutoMapper
- Select2 (para dropdowns melhorados)
- Bootstrap 5

---

## 🗂️ Organização em Camadas

- `Core`: Entidades e interfaces
- `Application`: DTOs, Services e lógica de negócio
- `Infrastructure`: DbContext e acesso a dados
- `Web`: Controllers, Views e ViewModels
- `Database`: Migrações EF Core

---

## ▶️ Como Executar

1. Clone o repositório
2. No terminal, execute:
   ```bash
   dotnet ef database update
   dotnet run
   ```
3. Acesse: [http://localhost:5065](http://localhost:5065)

---

## 🧪 Teste Técnico

Este projeto foi desenvolvido com base no enunciado técnico fornecido. Para visualizar as respostas do candidato ao desafio, acesse:

📎 [Respostas.txt](Respostas.txt)

---

## 🧑‍💻 Autor

Desenvolvido por @m4r6i0 para fins de demonstração e avaliação técnica.
