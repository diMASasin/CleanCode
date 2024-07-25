using CleanCode.OCP.PaymentSystems;

namespace CleanCode.OCP;

public interface IPaymentSystemFactory
{
    public IEnumerable<string> PaymentSystemNames { get; }
    public Func<IPaymentSystem> GetFactoryMethod(string id);
}