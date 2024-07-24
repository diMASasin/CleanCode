namespace CleanCode.CleanCode_ExampleTask21_27;

public class Passport
{
    private const string WhiteSpaceEnteredMessage = "Введите серию и номер паспорта";
    private const string WrongFormat = "Неверный формат серии или номера паспорта";
    private const int NumberLength = 10;

    public string Number { get; private set; }
    
    public event Action<string> WhiteSpaceEntered;
    public event Action<string> WrongLength;
    
    public bool TrySetNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(Number) == true)
        {
            WhiteSpaceEntered?.Invoke(WhiteSpaceEnteredMessage);
            return false;
        }

        if (Number.Length < NumberLength)
        {
            WrongLength?.Invoke(WrongFormat);
            return false;
        }
        
        Number = number;

        return true;
    }
}