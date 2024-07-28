using CleanCode.CleanCode_ExampleTask21_27.Presenter;

namespace CleanCode.CleanCode_ExampleTask21_27.External;

public class RemoteVotingView : IDisposable, IRemoteVotingView
{
    private readonly Button _checkButton;
    private readonly RemoteVotingPresenter _remoteVotingPresenter;

    private TextBox _textResult;
    private TextBox _passportTextbox;

    public RemoteVotingView()
    {
        _remoteVotingPresenter = new RemoteVotingPresenter(this);
        
        _checkButton.Clicked += OnClicked;
    }

    public void Dispose()
    {
        _checkButton.Clicked -= OnClicked;
    }

    private void OnClicked() => _remoteVotingPresenter.OnCheckBoxButtonClicked(_textResult.Text);

    public void ShowResult(string text) => _textResult.Text = text;

    public void ShowMessage(string text) => MessageBox.Show(text);
}