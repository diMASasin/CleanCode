namespace CleanCode.OCP.PaymentSystems;

public class PaymentSystem
{
    private readonly string _initializeMessage;
    private readonly string _checkPaymentMessege;

    public PaymentSystem(string initializeMessege, string checkPaymentMessege)
    {
        _initializeMessage = initializeMessege;
        _checkPaymentMessege = checkPaymentMessege;
    }

    public void ShowInitializeMessege() => Console.WriteLine(_initializeMessage);
    public void ShowCheckPaymentMessege() => Console.WriteLine(_checkPaymentMessege);
}