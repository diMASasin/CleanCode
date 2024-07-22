namespace MethodName.OCP;

public class PaymentHandler
{
    public void ShowPaymentResult(PaymentSystem paymentSystem)
    {
        if (paymentSystem == null) 
            throw new ArgumentNullException(nameof(paymentSystem));
        
        Console.WriteLine($"Вы оплатили с помощью {paymentSystem}");
            
        paymentSystem.ShowCheckPaymentMessege();
        Console.WriteLine("Оплата прошла успешно!");
    }
}