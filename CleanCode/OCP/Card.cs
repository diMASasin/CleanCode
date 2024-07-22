namespace MethodName.OCP;

public class Card : PaymentSystem
{
    public Card(string id) : base(id)
    {
    }

    public override void ShowInitializeMessege() => Console.WriteLine("Вызов API банка эмитера карты Card...");

    public override void ShowCheckPaymentMessege() => Console.WriteLine("Проверка платежа через Card...");
}