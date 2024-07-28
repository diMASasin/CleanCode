using CleanCode.CleanCode_ExampleTask21_27.Presenter;

namespace CleanCode.CleanCode_ExampleTask21_27.Model;

public class CitizenFinder
{
    private readonly AccessApprovementChecker _accessApprovementChecker = new();
    private readonly FileHandler _fileHandler = new();

    public Citizen GetCitizen(string serialNumber)
    {
        string filePath = _fileHandler.FindFile();
        bool isAccessApproved = _accessApprovementChecker.IsAccessApproved(serialNumber, filePath);

        return new Citizen(new Passport(serialNumber), isAccessApproved);
    }
}