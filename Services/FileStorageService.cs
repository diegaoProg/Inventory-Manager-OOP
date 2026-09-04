using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventoryManager.Entities;

namespace InventoryManager.Services
{
    // [PERSISTÊNCIA] Lida com I/O (Input/Output) do disco rígido.
    public class FileStorageService
    {
        private readonly string _filePath = "sales_history.json";

        public void SaveSales(List<SaleRecord> sales)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(sales, options);
            File.WriteAllText(_filePath, json);
        }

        public List<SaleRecord> LoadSales()
        {
            if (!File.Exists(_filePath)) return new List<SaleRecord>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<SaleRecord>>(json);
        }
    }
}