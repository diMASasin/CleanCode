namespace CleanCode.OCP.PaymentSystems;

public class Qiwi : IPaymentSystem
{
    public void ShowInitializeMessege() => Console.WriteLine("Проверка платежа через QIWI...");

    public void ShowCheckPaymentMessege() => Console.WriteLine("Перевод на страницу QIWI...");
}