using System;

namespace InventoryManager.Entities
{
    // Entidade simples para guardar o histórico de vendas para salvar no JSON!
    public class SaleRecord
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }
    }
}