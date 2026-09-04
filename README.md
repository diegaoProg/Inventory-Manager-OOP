# MiniSistema de Gestão de TI (Inventory Manager)

## Sobre o Projeto
Este é um projeto de conclusão (Capstone) desenvolvido em C# (.NET) para consolidar os fundamentos da **Programação Orientada a Objetos (POO)**. O sistema atua no terminal (Console Application) e simula o gerenciamento de estoque, reposição e vendas de uma loja de equipamentos de TI e licenças de software.

## Funcionalidades
- **Catálogo Dinâmico:** Visualização de produtos físicos (hardware) e digitais (licenças).
- **Frente de Caixa:** Registro de vendas com baixa automática (e segura) de estoque.
- **Gestão de Inventário:** Sistema para repor o estoque de mercadorias.
- **Auditoria:** Extrato financeiro com histórico de todas as transações e faturamento total.
- **Persistência de Dados:** O sistema não perde os dados ao ser fechado, salvando todo o histórico em um arquivo `.json` local.

## Conceitos Técnicos Aplicados
Neste projeto, saís da lógica procedural estruturada e apliquei os padrões de mercado da plataforma .NET:

- **Programação Orientada a Objetos (POO):**
  - **Abstração:** Modelagem das entidades `Product` e `SaleRecord`.
  - **Herança:** Classes `PhysicalProduct` e `DigitalLicense` herdando regras da classe base.
  - **Polimorfismo:** Modificação do comportamento de exibição através do `override` no método `GetDetails()`.
  - **Encapsulamento:** Proteção do estado interno dos objetos, garantindo que o estoque só seja alterado por métodos seguros (`TrySell` e `AddStock`).
  - **Interfaces:** Criação de um contrato `IPaymentService` para desacoplar a lógica de pagamentos.
- **Manipulação de Coleções:** Substituição de Arrays paralelos por `List<T>`.
- **LINQ (Language Integrated Query):** Consultas em memória usando `OrderBy`, `FirstOrDefault` e `Sum`.
- **I/O & Serialização JSON:** Leitura e gravação no disco utilizando a biblioteca nativa `System.Text.Json`.

## Estrutura do Projeto
- `/Entities` - Contém os moldes e regras das entidades do domínio.
- `/Services` - Lida com lógicas externas, como persistência em arquivo e pagamentos.
- `Program.cs` - Ponto de entrada, menu interativo e orquestração do sistema.

## Como Executar
Primeiramente, se certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.
No terminal, execute:

```bash
# Clone o repositório
git clone [https://github.com/diegaoProg/Inventory-Manager-OOP.git](https://github.com/SEU_USUARIO/Inventory-Manager-OOP.git)

# Acesse a pasta do projeto
cd Inventory-Manager-OOP

# Execute a aplicação
dotnet run
