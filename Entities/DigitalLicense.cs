namespace InventoryManager.Entities
{
    // [POO - HERANÇA] Adiciona a chave de ativação para produtos digitais.
    public class DigitalLicense : Product
    {
        public string ActivationPlatform { get; private set; }

        public DigitalLicense(int id, string name, decimal price, int stockQuantity, string activationPlatform)
            : base(id, name, price, stockQuantity)
        {
            ActivationPlatform = activationPlatform;
        }

        // [POO - POLIMORFISMO] Formatação específica para licenças.
        public override string GetDetails()
        {
            return $"[DIGITAL] {base.GetDetails()} | Plataforma: {ActivationPlatform}";
        }
    }
}