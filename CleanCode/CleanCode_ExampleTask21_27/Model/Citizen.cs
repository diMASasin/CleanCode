namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class Citizen
{
    public Passport Passport { get; private set; }
    public bool IsAccessApproved { get; private set; }

    public Citizen(Passport passport, bool isAccessApproved)
    {
        Passport = passport ?? throw new ArgumentNullException(nameof(passport));
        
        IsAccessApproved = isAccessApproved;
    }
}