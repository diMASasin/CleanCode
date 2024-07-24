using System.Text;

namespace CleanCode.OCP;

public class OrderForm
{
    public string ShowForm(IEnumerable<string> paymentSystemNames)
    {
        StringBuilder paymentSystems = new();
        paymentSystems.AppendJoin(' ', paymentSystemNames);
        
        Console.WriteLine("Мы принимаем: " + paymentSystems);

        //симуляция веб интерфейса
        Console.WriteLine("Какое системой вы хотите совершить оплату?");
        return Console.ReadLine();
    }
}