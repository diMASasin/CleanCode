using CleanCode.OCP.PaymentSystems;

namespace CleanCode.OCP;

public class PaymentSystemFactory : IPaymentSystemFactory
{
    private readonly Dictionary<string, Func<IPaymentSystem>> _paymentSystems = new()
    {
        { "QIWI", () => new Qiwi() },
        { "WebMoney", () => new WebMoney() },
        { "Card", () => new Card() }
    };

    public IEnumerable<string> PaymentSystemNames => _paymentSystems.Keys;

    public Func<IPaymentSystem> GetFactoryMethod(string id) => _paymentSystems[id];
}