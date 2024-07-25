namespace CleanCode.OCP;

public class Program
{
    public static void Main(string[] args)
    {
        var orderForm = new OrderForm();
        var paymentSystemFactory = new PaymentSystemFactory();
        
        string systemId = orderForm.ShowForm(paymentSystemFactory.PaymentSystemNames);
        PaymentHandler paymentHandler = new(paymentSystemFactory.GetFactoryMethod(systemId));

        paymentHandler.ShowPaymentResult(systemId);
    }
}