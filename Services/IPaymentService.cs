namespace InventoryManager.Services
{
    // [POO - INTERFACES] Contrato que obriga a implementação do processamento de pagamento.
    public interface IPaymentService
    {
        bool ProcessPayment(decimal amount);
    }

    // Implementação 1: Pagamento em Dinheiro
    public class CashPaymentService : IPaymentService
    {
        public bool ProcessPayment(decimal amount)
        {
            System.Console.WriteLine($"[Pagamento] Recebido {amount:C2} em espécie. Gaveta aberta.");
            return true;
        }
    }
}