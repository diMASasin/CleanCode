namespace CleanCode.OCP.PaymentSystems;

public class Qiwi : IPaymentSystem
{
    public  void ShowInitializeMessege() => Console.WriteLine("Перевод на страницу QIWI...");
    public  void ShowCheckPaymentMessege() => Console.WriteLine("Проверка платежа через QIWI...");
}