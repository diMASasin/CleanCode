using CleanCode.CleanCode_ExampleTask21_27.External;

namespace CleanCode.CleanCode_ExampleTask21_27;

public class Program
{
    private static RemoteVotingView _remoteVotingView;

    private static void Main(string[] args)
    {
        _remoteVotingView = new RemoteVotingView();
    }

    //imagine that this method is called when you exit the application
    private static void OnApplicationExit()
    {
        _remoteVotingView.Dispose();
    }
}