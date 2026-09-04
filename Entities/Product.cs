namespace InventoryManager.Entities
{
    // [POO - ABSTRAÇÃO] Representa o conceito genérico de um produto.
    public class Product
    {
        // [POO - ENCAPSULAMENTO] O 'set' é protegido (protected) ou privado para evitar alterações indevidas.
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; protected set; }

        // [POO - CONSTRUTOR] Força a inicialização com dados válidos.
        public Product(int id, string name, decimal price, int stockQuantity)
        {
            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        // [POO - ENCAPSULAMENTO] Método seguro para baixar estoque.
        public bool TrySell(int quantity)
        {
            if (quantity > 0 && StockQuantity >= quantity)
            {
                StockQuantity -= quantity;
                return true;
            }
            return false;
        }

        // [POO - ENCAPSULAMENTO] Método seguro para entrada de mercadoria.
        public void AddStock(int quantity)
        {
            if (quantity > 0)
            {
                StockQuantity += quantity;
            }
        }

        // [POO - POLIMORFISMO] O 'virtual' permite que classes filhas modifiquem a exibição.
        public virtual string GetDetails()
        {
            return $"[{Id}] {Name} - {Price:C2} | Estoque: {StockQuantity} un";
        }
    }
}