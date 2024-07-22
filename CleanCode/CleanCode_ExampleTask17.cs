namespace MethodName;

public class CleanCode_ExampleTask17
{
    private static int _hourlyRate;
    private static int _chance;

    public static void CreateObject()
    {
        //Создание объекта на карте
    }

    public static void RandomizeChance()
    {
        _chance = Random.Range(0, 100);
    }

    public static int GetSalaryAmount(int hoursWorked)
    {
        return _hourlyRate * hoursWorked;
    }
}

public static class Random
{
    public static int Range(int value1, int value2) => 52;
}