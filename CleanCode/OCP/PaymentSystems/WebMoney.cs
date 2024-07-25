namespace CleanCode.OCP.PaymentSystems;

public class WebMoney : IPaymentSystem
{
    public void ShowInitializeMessege() => Console.WriteLine("Вызов API WebMoney...");

    public void ShowCheckPaymentMessege() => Console.WriteLine("Проверка платежа через WebMoney...");
}