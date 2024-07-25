using CleanCode.OCP.PaymentSystems;

namespace CleanCode.OCP;

public class PaymentHandler
{
    private IPaymentSystem _paymentSystem;

    public PaymentHandler(Func<IPaymentSystem> createPaymentSystem)
    {
        _paymentSystem = createPaymentSystem();
    }

    public void ShowPaymentResult(string systemIndex)
    {
        if (_paymentSystem == null) 
            throw new ArgumentNullException(nameof(_paymentSystem));
        
        Console.WriteLine($"Вы оплатили с помощью {systemIndex}");
            
        _paymentSystem.ShowCheckPaymentMessege();
        Console.WriteLine("Оплата прошла успешно!");
    }
}