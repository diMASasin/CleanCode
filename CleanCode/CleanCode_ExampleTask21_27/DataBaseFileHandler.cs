using System.Reflection;

namespace MethodName.CleanCode_ExampleTask21_27;

public class DataBaseFileHandler
{
    private readonly string _assemblyLocation;
    
    public string ConnectionString { get; private set; }
    public string FilePath { get; private set; }

    public DataBaseFileHandler(string dataBaseFileName)
    {
        _assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        FilePath = Path.Combine(_assemblyLocation, dataBaseFileName);
        ConnectionString = $"Data Source={FilePath}";
    }
}