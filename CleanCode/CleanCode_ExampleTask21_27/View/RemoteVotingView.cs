using CleanCode.CleanCode_ExampleTask21_27.Presenter;

namespace CleanCode.CleanCode_ExampleTask21_27.External;

public class RemoteVotingView : IDisposable
{
    public readonly TextBox TextResult;
    public readonly TextBox PassportTextbox;

    private readonly Button _checkButton;
    
    private readonly RemoteVotingPresenter _remoteVotingPresenter;

    public RemoteVotingView()
    {
        _remoteVotingPresenter = new RemoteVotingPresenter(this);
        
        _checkButton.Clicked += OnClicked;
    }

    public void Dispose()
    {
        _checkButton.Clicked -= OnClicked;
        
        _remoteVotingPresenter.Dispose();
    }

    private void OnClicked() => _remoteVotingPresenter.OnCheckBoxButtonClicked();
}