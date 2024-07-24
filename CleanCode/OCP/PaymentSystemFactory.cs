using CleanCode.OCP.PaymentSystems;

namespace CleanCode.OCP;

public class PaymentSystemFactory : IPaymentSystemFactory
{
    private readonly Dictionary<string, Func<PaymentSystem>> _paymentSystems = new()
    {
        { "QIWI", () => new PaymentSystem("Перевод на страницу QIWI...", "Проверка платежа через QIWI...") },
        { "WebMoney", () => new PaymentSystem("Вызов API WebMoney...", "Проверка платежа через WebMoney...") },
        { "Card", () => new PaymentSystem("Вызов API банка эмитера карты Card...", "Проверка платежа через Card...") }
    };

    public IEnumerable<string> PaymentSystemNames => _paymentSystems.Keys;

    public PaymentSystem Create(string id) => _paymentSystems[id]();
}