using System.Reflection;

namespace CleanCode.CleanCode_ExampleTask21_27;

public class FileHandler
{
    private const string FileNotFound = $"Файл {DataBaseFileName} не найден. Положите файл в папку вместе с exe.";
    private const string DataBaseFileName = "db.sqlite";
    
    public event Action<string> FileDoesntExist;
    
    public bool TryFindFile(out string FilePath)
    {
        string? assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        FilePath = Path.Combine(assemblyLocation, DataBaseFileName);

        if (File.Exists(FilePath) == false)
        {
            FileDoesntExist?.Invoke(FileNotFound);
            return false;
        }

        return true;
    }
}