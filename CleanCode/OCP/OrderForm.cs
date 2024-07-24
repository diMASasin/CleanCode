namespace CleanCode.OCP;

public class OrderForm
{
    public string ShowForm(IEnumerable<string> paymentSystemNames)
    {
        Console.WriteLine("Мы принимаем: " + string.Join(' ', paymentSystemNames));

        //симуляция веб интерфейса
        Console.WriteLine("Какое системой вы хотите совершить оплату?");
        return Console.ReadLine();
    }
}