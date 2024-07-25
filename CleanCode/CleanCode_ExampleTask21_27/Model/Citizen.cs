namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class Citizen
{
    public Passport Passport { get; private set; }
    public bool IsAccessApproved { get; private set; }

    public Citizen(Passport passport)
    {
        Passport = passport ?? throw new ArgumentNullException(nameof(passport));
    }

    public void ApproveAccess() => IsAccessApproved = true;
}