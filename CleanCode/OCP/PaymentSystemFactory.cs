using System.ComponentModel;

namespace MethodName.OCP;

public class PaymentSystemFactory
{
    public static PaymentSystem Create(string id)
    {
        return id switch
        {
            "QIWI" => new Qiwi(id),
            "WebMoney" => new WebMoney(id),
            "Card" => new Card(id),
            _ => throw new InvalidEnumArgumentException(nameof(id))
        };
    }
}