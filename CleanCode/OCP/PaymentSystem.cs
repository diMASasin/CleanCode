namespace MethodName.OCP;

public abstract class PaymentSystem
{
    public string Id { get; }

    public PaymentSystem(string id)
    {
        Id = id;
    }
        
    public abstract void ShowInitializeMessege();
    public abstract void ShowCheckPaymentMessege();
}