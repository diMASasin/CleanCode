using System.Reflection;

namespace CleanCode.CleanCode_ExampleTask21_27;

public class FileHandler
{
    private const string FileNotFound = $"Файл {DataBaseFileName} не найден. Положите файл в папку вместе с exe.";
    private const string DataBaseFileName = "db.sqlite";
    
    public string FindFile()
    {
        string? assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        string filePath = Path.Combine(assemblyLocation, DataBaseFileName);

        if (File.Exists(filePath) == false)
            throw new FileNotFoundException(FileNotFound);
        
        return filePath;
    }
}