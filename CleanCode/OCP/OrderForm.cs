namespace MethodName.OCP;

public class OrderForm
{
    public string ShowForm()
    {
        Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");

        //симуляция веб интерфейса
        Console.WriteLine("Какое системой вы хотите совершить оплату?");
        return Console.ReadLine();
    }
}