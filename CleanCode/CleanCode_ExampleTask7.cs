namespace MethodName;

public class CleanCode_ExampleTask2
{
    public static int GetIndex(int[] array, int element)
    {
        for (int i = 0; i < array.Length; i++)
            if (array[i] == element)
                return i;

        return -1;
    }
}
