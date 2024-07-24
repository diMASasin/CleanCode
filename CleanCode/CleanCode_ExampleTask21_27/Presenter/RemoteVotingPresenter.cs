using CleanCode.CleanCode_ExampleTask21_27.External;

namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class RemoteVotingPresenter : IDisposable
{
    private readonly Passport _passport = new();
    private readonly FileHandler _fileHandler = new();
    private readonly AccessApprovementChecker _accessApprovementChecker = new();
    private readonly RemoteVotingView _view;
    
    private TextBox TextResult => _view.TextResult;

    public RemoteVotingPresenter(RemoteVotingView view)
    {
        _view = view;
        
        _passport.WhiteSpaceEntered += ShowInMessageBox;
        _passport.WrongLength += ShowInResultTextBox;
        _fileHandler.FileDoesntExist += ShowInMessageBox;
        _accessApprovementChecker.EmptyTableGot += ShowInResultTextBox;
        _accessApprovementChecker.AccessNotApproved += ShowInResultTextBox;
    }

    public void Dispose()
    {
        _passport.WhiteSpaceEntered -= ShowInMessageBox;
        _passport.WrongLength -= ShowInResultTextBox;
        _fileHandler.FileDoesntExist -= ShowInMessageBox;
        _accessApprovementChecker.EmptyTableGot -= ShowInResultTextBox;
        _accessApprovementChecker.AccessNotApproved -= ShowInResultTextBox;
    }

    public void OnCheckBoxButtonClicked()
    {
        string passportNumber = _view.PassportTextbox.Text.Replace(" ", string.Empty);
        
        if(_passport.TrySetNumber(passportNumber) == false)
            return;

        if(_fileHandler.TryFindFile(out string filePath) == false)
            return;
        
        if(_accessApprovementChecker.IsAccessApproved(_passport.Number, filePath) == false)
            return;
        
        ShowAccessApprovingMessage();
    }

    private void ShowAccessApprovingMessage() => 
        TextResult.Text = 
            $"По паспорту «{_passport.Number}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";

    private void ShowInMessageBox(string text) => MessageBox.Show(text);

    private void ShowInResultTextBox(string text) => TextResult.Text = text;
}