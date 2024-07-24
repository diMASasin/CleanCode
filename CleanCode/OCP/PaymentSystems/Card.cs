namespace CleanCode.OCP.PaymentSystems;

public class Card : IPaymentSystem
{
    public void ShowInitializeMessege() => Console.WriteLine("Вызов API банка эмитера карты Card...");
    public void ShowCheckPaymentMessege() => Console.WriteLine("Проверка платежа через Card...");
}