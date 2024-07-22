namespace MethodName.OCP;

public class Qiwi : PaymentSystem
{
    public Qiwi(string id) : base(id)
    {
    }

    public override void ShowInitializeMessege() => Console.WriteLine("Перевод на страницу QIWI...");

    public override void ShowCheckPaymentMessege() => Console.WriteLine("Проверка платежа через QIWI...");
}