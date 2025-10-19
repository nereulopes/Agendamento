# 🏋️‍♂️ Agendamento de Aulas - Academia

API desenvolvida em **.NET 8** com **Entity Framework Core (SQLite)** para gerenciar:

- Cadastro de alunos (Mensal, Trimestral, Anual)
- Cadastro de aulas (Cross, Funcional, Pilates)
- Agendamento respeitando limites do plano e capacidade máxima
- Relatório mensal de frequência

---

## 🚀 Tecnologias
- ASP.NET Core 8
- Entity Framework Core
- SQLite
- Swagger UI

---

## 💾 Banco de Dados
Um arquivo `agendamento.db` já está incluído no repositório.  
Ele contém as tabelas e alguns dados de exemplo prontos para teste.

> Se preferir recriar o banco do zero:
dotnet ef database update

---

## 🧠 Estrutura da Solução
- Agendamento.Api/ → Controllers e configuração da API
- Agendamento.Aplicacao/ → Serviços e regras de negócio
- Agendamento.Dominio/ → Entidades e enums
- Agendamento.Repositorio/ → Interfaces e repositórios EF
- Agendamento.Infra/ → DbContext e Migrations

