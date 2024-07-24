using CleanCode.OCP.PaymentSystems;

namespace CleanCode.OCP;

public class PaymentHandler
{
    private readonly IPaymentSystemFactory _paymentSystemFactory;

    public PaymentHandler(IPaymentSystemFactory paymentSystemFactory)
    {
        _paymentSystemFactory = paymentSystemFactory;
    }

    public void ShowPaymentResult(string systemIndex)
    {
        var paymentSystem = _paymentSystemFactory.Create(systemIndex);
        
        if (paymentSystem == null) 
            throw new ArgumentNullException(nameof(paymentSystem));
        
        Console.WriteLine($"Вы оплатили с помощью {systemIndex}");
            
        paymentSystem.ShowCheckPaymentMessege();
        Console.WriteLine("Оплата прошла успешно!");
    }
}