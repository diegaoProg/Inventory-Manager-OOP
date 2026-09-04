using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManager.Entities;
using InventoryManager.Services;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStorageService storage = new FileStorageService();
            List<SaleRecord> salesHistory = storage.LoadSales();

            List<Product> catalog = new List<Product>
            {
                new PhysicalProduct(1, "Roteador Cisco", 1500.00m, 5, 2.5),
                new PhysicalProduct(2, "Patch Cord CAT6", 15.00m, 50, 0.1),
                new DigitalLicense(3, "Docker Pro", 350.00m, 99, "Docker Hub"),
                new DigitalLicense(4, "Windows Server", 2500.00m, 10, "Microsoft Volume Licensing")
            };

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("============================================");
                Console.WriteLine("====== SISTEMA DE GESTÃO LOJA DE TI  =======");
                Console.WriteLine("====     conclusão do BASICO I e II     ====");
                Console.WriteLine("1. Ver Catálogo de Produtos");
                Console.WriteLine("2. Realizar Venda");
                Console.WriteLine("3. Repor Estoque"); 
                Console.WriteLine("4. Ver Extrato Financeiro");
                Console.WriteLine("0. Sair (Salvar no JSON)");
                Console.Write("\nEscolha uma opção: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- CATÁLOGO DE PRODUTOS ---");
                        foreach (var product in catalog.OrderBy(p => p.Name))
                        {
                            Console.WriteLine(product.GetDetails());
                        }
                        break;

                    case "2":
                        Console.Write("\nDigite o ID do produto para vender: ");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            Product selectedProduct = catalog.FirstOrDefault(p => p.Id == productId);

                            if (selectedProduct != null)
                            {
                                Console.Write($"Quantas unidades de '{selectedProduct.Name}' deseja vender? ");
                                if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
                                {
                                    if (selectedProduct.TrySell(qty))
                                    {
                                        decimal total = selectedProduct.Price * qty;

                                        IPaymentService payment = new CashPaymentService();
                                        payment.ProcessPayment(total);

                                        SaleRecord record = new SaleRecord
                                        {
                                            Date = DateTime.Now,
                                            ProductName = selectedProduct.Name,
                                            Quantity = qty,
                                            TotalValue = total
                                        };
                                        salesHistory.Add(record);

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Venda realizada com sucesso!");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Estoque insuficiente!");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }
                        Console.ResetColor();
                        break;

                    // <-- INÍCIO DA NOVA LÓGICA DE REPOSIÇÃO -->
                    case "3":
                        Console.Write("\nDigite o ID do produto para repor estoque: ");
                        if (int.TryParse(Console.ReadLine(), out int restockId))
                        {
                            Product productToRestock = catalog.FirstOrDefault(p => p.Id == restockId);

                            if (productToRestock != null)
                            {
                                Console.Write($"Quantas unidades de '{productToRestock.Name}' chegaram? ");
                                if (int.TryParse(Console.ReadLine(), out int qtyToAdd) && qtyToAdd > 0)
                                {
                                    productToRestock.AddStock(qtyToAdd); // Chama o novo método seguro

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Estoque atualizado com sucesso!");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Quantidade inválida. Digite um número maior que zero.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }
                        Console.ResetColor();
                        break;
                    

                    case "4":
                        Console.WriteLine("\n--- EXTRATO FINANCEIRO ---");
                        if (salesHistory.Count == 0)
                        {
                            Console.WriteLine("Nenhuma venda registrada ainda.");
                        }
                        else
                        {
                            foreach (var sale in salesHistory.OrderByDescending(s => s.Date))
                            {
                                Console.WriteLine($"[{sale.Date:dd/MM HH:mm}] {sale.Quantity}x {sale.ProductName} - {sale.TotalValue:C2}");
                            }

                            decimal grandTotal = salesHistory.Sum(s => s.TotalValue);
                            Console.WriteLine($"\nFaturamento Total: {grandTotal:C2}");
                        }
                        break;

                    case "0":
                        storage.SaveSales(salesHistory);
                        Console.WriteLine("Extrato salvo com sucesso. Encerrando o sistema...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}