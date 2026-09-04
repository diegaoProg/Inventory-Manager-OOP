[Ler em Português](#sistema-de-gestão-de-ti-inventory-manager-oop) | [Read in English](#it-management-system-inventory-manager-oop)

---

# Sistema de Gestão de TI (Inventory Manager OOP)

## Sobre o Projeto
Este é um projeto de conclusão (Capstone) desenvolvido em C# (.NET) para consolidar os fundamentos da **Programação Orientada a Objetos (POO)**. O sistema atua no terminal (Console Application) e simula o gerenciamento de estoque, reposição e vendas de uma loja de equipamentos de TI e licenças de software.

## Funcionalidades
- **Catálogo Dinâmico:** Visualização de produtos físicos (hardware) e digitais (licenças).
- **Frente de Caixa:** Registro de vendas com baixa automática e segura de estoque.
- **Gestão de Inventário:** Sistema para repor o estoque de mercadorias.
- **Auditoria:** Extrato financeiro com histórico de todas as transações e faturamento total.
- **Persistência de Dados:** O sistema não perde os dados ao ser fechado, salvando todo o histórico em um arquivo `.json` local.

## Conceitos Técnicos Aplicados
Neste projeto, saímos da lógica procedural estruturada e aplicamos os padrões de mercado da plataforma .NET:

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
Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado. No terminal, execute:

```bash
git clone [https://github.com/diegaoProg/Inventory-Manager-OOP.git](https://github.com/diegaoProg/Inventory-Manager-OOP.git)
cd Inventory-Manager-OOP
dotnet run
```

---

# IT Management System (Inventory Manager OOP)

## About the Project
This is a Capstone project developed in C# (.NET) to consolidate the fundamentals of **Object-Oriented Programming (OOP)**. The system runs in the terminal (Console Application) and simulates the inventory management, restocking, and sales of an IT equipment and software license store.

## Features
- **Dynamic Catalog:** Visualization of physical products (hardware) and digital products (licenses).
- **Point of Sale (POS):** Sales registration with automatic and secure stock deduction.
- **Inventory Management:** System to restock merchandise.
- **Auditing:** Financial ledger with a history of all transactions and total revenue.
- **Data Persistence:** The system does not lose data when closed, saving the entire history in a local `.json` file.

## Applied Technical Concepts
In this project, we moved away from structured procedural logic and applied the industry standards of the .NET platform:

- **Object-Oriented Programming (OOP):**
  - **Abstraction:** Modeling the `Product` and `SaleRecord` entities.
  - **Inheritance:** `PhysicalProduct` and `DigitalLicense` classes inheriting rules from the base class.
  - **Polymorphism:** Modifying the display behavior through the `override` keyword in the `GetDetails()` method.
  - **Encapsulation:** Protecting the internal state of objects, ensuring that stock is only altered by secure methods (`TrySell` and `AddStock`).
  - **Interfaces:** Creating an `IPaymentService` contract to decouple the payment logic.
- **Collections Manipulation:** Replacing parallel arrays with dynamic `List<T>`.
- **LINQ (Language Integrated Query):** In-memory queries using `OrderBy`, `FirstOrDefault`, and `Sum`.
- **I/O & JSON Serialization:** Reading and writing to disk using the native `System.Text.Json` library.

## Project Structure
- `/Entities` - Contains the blueprints and business rules for the domain entities.
- `/Services` - Handles external logic, such as file persistence and payments.
- `Program.cs` - Entry point, interactive menu, and system orchestration.

## How to Run
Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed. In the terminal, run:

git clone [https://github.com/diegaoProg/Inventory-Manager-OOP.git](https://github.com/diegaoProg/Inventory-Manager-OOP.git)
cd Inventory-Manager-OOP
dotnet run
