namespace CleanCode;

public class CleanCode_ExampleTask17
{
    private static int _hourlyRate;
    private static int _chance;

    public static void CreateObject()
    {
        //Создание объекта на карте
    }

    public static void SetRandomChance()
    {
        _chance = Random.Range(0, 100);
    }

    public static int CalculateSalary(int hoursWorked)
    {
        return _hourlyRate * hoursWorked;
    }
}