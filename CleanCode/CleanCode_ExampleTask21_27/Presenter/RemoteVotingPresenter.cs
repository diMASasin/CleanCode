using CleanCode.CleanCode_ExampleTask21_27.External;
using CleanCode.CleanCode_ExampleTask21_27.Model;

namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class RemoteVotingPresenter
{
    private readonly CitizenFinder _citizenFinder = new();
    private readonly IRemoteVotingView _view;

    public RemoteVotingPresenter(IRemoteVotingView view)
    {
        _view = view;
    }
    
    public void OnCheckBoxButtonClicked(string passportSerialNumber)
    {
        Citizen citizen = null;
        try
        {
            citizen = _citizenFinder.GetCitizen(passportSerialNumber);
        }
        catch (Exception exception)
        {
            if (exception is ArgumentNullException or FileNotFoundException)
                _view.ShowMessage(exception.Message);
            else
                _view.ShowResult(exception.Message);
            
            return;
        }

        string approvingText = citizen.IsAccessApproved == true ? "ПРЕДОСТАВЛЕН" : "ЗАПРЕЩЕН";
        _view.ShowResult(GetAccessApprovingMessage(citizen.Passport.SerialNumber, approvingText));
    }

    private string GetAccessApprovingMessage(string serialNumber, string approvingText) =>
        $"По паспорту «{serialNumber}» доступ к бюллетеню на дистанционном электронном голосовании {approvingText}";
}