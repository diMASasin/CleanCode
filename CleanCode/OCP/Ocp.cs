using CleanCode.OCP.PaymentSystems;

namespace CleanCode.OCP;

public class Program
{
    private static Qiwi _qiwi;
    private static WebMoney _webMoney;
    private static Card _card;
    
    public static void Main(string[] args)
    {
        var orderForm = new OrderForm();
        var paymentSystemFactory = new PaymentSystemFactory();
        var paymentHandler = new PaymentHandler(paymentSystemFactory);
        
        string systemId = orderForm.ShowForm(paymentSystemFactory.PaymentSystemNames);

        paymentHandler.ShowPaymentResult(systemId);
    }
}