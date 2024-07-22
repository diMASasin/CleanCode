namespace MethodName.OCP;

public class Program
{
    private static Qiwi _qiwi;
    private static WebMoney _webMoney;
    private static Card _card;

    public static void Main(string[] args)
    {
        var orderForm = new OrderForm();
        var paymentHandler = new PaymentHandler();

        string systemId = orderForm.ShowForm();

        PaymentSystem paymentSystem = PaymentSystemFactory.Create(systemId);
        paymentSystem.ShowInitializeMessege();

        paymentHandler.ShowPaymentResult(paymentSystem);
    }
}