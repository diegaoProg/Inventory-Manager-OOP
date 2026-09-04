namespace InventoryManager.Entities
{
    // [POO - HERANÇA] PhysicalProduct herda tudo de Product e adiciona peso.
    public class PhysicalProduct : Product
    {
        public double WeightKg { get; private set; }

        public PhysicalProduct(int id, string name, decimal price, int stockQuantity, double weightKg)
            : base(id, name, price, stockQuantity) // Chama o construtor da classe pai
        {
            WeightKg = weightKg;
        }

        // [POO - POLIMORFISMO] Sobrescreve o método para mostrar o peso.
        public override string GetDetails()
        {
            return $"[FÍSICO] {base.GetDetails()} | Peso: {WeightKg}kg";
        }
    }
}