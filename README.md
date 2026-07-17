# EmployeeManagement

API REST para gestão de funcionários, construída em **ASP.NET Core (.NET 10)** seguindo arquitetura em camadas, com **MySQL** como banco de dados via **Entity Framework Core**.

Projeto pessoal de estudo backend, com foco em aplicar princípios sólidos de design (SOLID, injeção de dependência, Repository Pattern) e cobertura de testes unitários com xUnit e Moq.

## Arquitetura

O projeto segue uma separação em camadas:

```
Employee Management API/      → Controllers, DTOs (camada de apresentação)
EmployeeManagement/           → Domain (entidades), Services (regras de negócio),
                                 Repository (interfaces + implementações), Infrastructure (DbContext)
EmployeeManagement.Tests/     → Testes unitários (xUnit + Moq)
```

- **Domain** contém as entidades (`Employee`, `Department`, `JobPosition`) com suas próprias regras de negócio e validações — nada de classes anêmicas com apenas getters/setters.
- **Services** orquestra os casos de uso, dependendo apenas de interfaces (`IEmployeeRepository`, `IDepartmentRepository`, `IJobPositionRepository`), nunca das implementações concretas.
- **Repository** implementa o acesso a dados via EF Core, cada interface separada por responsabilidade (aplicação do Interface Segregation Principle).
- **Infrastructure** contém o `DbContextEF`, com o mapeamento explícito de relacionamentos entre `Employee`, `Department` e `JobPosition`.

## Funcionalidades

A API expõe os seguintes endpoints, via `EmployeeController`:

| Método | Rota | Ação |
|---|---|---|
| `POST` | `/api/employee` | Cadastra um novo funcionário |
| `PUT` | `/api/employee` | Edita department, cargo e senioridade de um funcionário existente |
| `PATCH` | `/api/employee` | Realiza o desligamento (layoff) de um funcionário |
| `GET` | `/api/employee` | Lista todos os funcionários |

### Regras de negócio implementadas

- **Cadastro inteligente de Department e JobPosition**: ao cadastrar um funcionário, o sistema busca se o department e o cargo informados já existem (por nome); se não existirem, cria-os automaticamente antes de vincular ao funcionário. Isso evita duplicidade de departamentos/cargos no banco.
- **Status automático por tempo de casa**: ao ser cadastrado, o funcionário recebe automaticamente o status `InExperience` (até 90 dias) ou `Active` (acima disso), calculado a partir da data de admissão.
- **Desligamento com trava de reescrita**: um funcionário já marcado como `Fired` não pode ser desligado novamente — o domínio lança uma exceção nesse caso, protegendo a integridade do histórico.
- **Validações no próprio domínio**: nome de funcionário, nome de department e nome de cargo não podem ser nulos, vazios ou compostos apenas por espaços — a validação vive na entidade, não depende de camadas externas lembrarem de validar.

## Modelo de dados

Principais tabelas (ver `schema.sql` para o script completo):

- **`Employees`** — dados do funcionário, com CPF (`CHAR(11)`), status, e datas de admissão/desligamento.
- **`Department`** — nome do departamento (único).
- **`JobPosition`** — cargo, vinculado a um department, com senioridade associada ao cargo (não ao funcionário diretamente).

> **Nota de design:** a senioridade (`Seniority`) é armazenada na entidade `JobPosition`, não em `Employee` — no domínio, `Employee.Seniority` existe como propriedade de conveniência (`[NotMapped]`), mas a fonte de verdade persistida é o cargo.

## Testes

O projeto conta com testes unitários (`EmployeeManagement.Tests`), cobrindo o `EmployeeService` com Moq para isolar as dependências de repositório:

- Cadastro de funcionário quando department e cargo já existem (evita recriação desnecessária).
- Edição de funcionário, validando a atualização de department, cargo e senioridade, além da persistência via repositório.

```bash
cd EmployeeManagement.Tests
dotnet test
```

## Como rodar localmente

### Pré-requisitos

- .NET 10 SDK
- MySQL Server rodando localmente

### Configuração

1. Execute o script `schema.sql` no seu MySQL para criar o banco `employee_db` e as tabelas.
2. Configure a connection string no `appsettings.json` do projeto **Employee Management API**, apontando para sua instância local do MySQL.
3. Restaure as dependências e rode a API:

```bash
cd "Employee Management API"
dotnet restore
dotnet run
```

A API sobe com Swagger habilitado para explorar os endpoints interativamente.

## Stack

- **ASP.NET Core** (.NET 10)
- **Entity Framework Core** + **Pomelo.EntityFrameworkCore.MySql**
- **MySQL**
- **xUnit** + **Moq** (testes unitários)

---

Desenvolvido por [Whoshington-Dev](https://github.com/Whoshington-Dev) como projeto de estudo em desenvolvimento backend com C#/.NET.