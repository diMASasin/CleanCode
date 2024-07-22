namespace MethodName;

public class CleanCode_ExampleTask1
{
    public static int GetValidNumber(int a, int b, int c)
    {
        return a < b ? b : Math.Min(a, c);
    }
}