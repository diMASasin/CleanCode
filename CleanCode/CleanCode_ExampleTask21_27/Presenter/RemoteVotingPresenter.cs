using CleanCode.CleanCode_ExampleTask21_27.External;

namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class RemoteVotingPresenter
{
    private readonly FileHandler _fileHandler = new();
    private readonly AccessApprovementChecker _accessApprovementChecker = new();
    
    public void OnCheckBoxButtonClicked(TextBox passportTextbox, TextBox textResult)
    {
        string passportNumber = passportTextbox.Text.Replace(" ", string.Empty);

        Citizen citizen = null;
        try
        {
            var passport = new Passport(passportNumber);
            citizen = new Citizen(passport);

            string filePath = _fileHandler.FindFile();
            
            _accessApprovementChecker.TryApproveAccess(citizen, filePath);
        }
        catch (Exception exception)
        {
            if (exception is ArgumentNullException or FileNotFoundException)
                MessageBox.Show(exception.Message);
            else
                textResult.Text = exception.Message;
            
            return;
        }

        string approvingText = citizen.IsAccessApproved == true ? "ПРЕДОСТАВЛЕН" : "ЗАПРЕЩЕН";
        textResult.Text = GetAccessApprovingMessage(citizen.Passport.SerialNumber, approvingText);
    }

    private string GetAccessApprovingMessage(string serialNumber, string approvingText) =>
        $"По паспорту «{serialNumber}» доступ к бюллетеню на дистанционном электронном голосовании {approvingText}";
}