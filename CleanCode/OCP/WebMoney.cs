namespace MethodName.OCP;

public class WebMoney : PaymentSystem
{
    public WebMoney(string id) : base(id)
    {
    }

    public override void ShowInitializeMessege() => Console.WriteLine("Вызов API WebMoney...");

    public override void ShowCheckPaymentMessege() => Console.WriteLine("Проверка платежа через WebMoney...");
}