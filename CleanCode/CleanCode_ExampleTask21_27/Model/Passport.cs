namespace CleanCode.CleanCode_ExampleTask21_27;

public class Passport
{
    private const string WhiteSpaceEnteredMessage = "Введите серию и номер паспорта";
    private const string WrongFormat = "Неверный формат серии или номера паспорта";
    private const int NumberLength = 10;

    public string SerialNumber { get; private set; }
    
    public Passport(string number)
    {
        if (string.IsNullOrWhiteSpace(number) == true) throw new ArgumentNullException(WhiteSpaceEnteredMessage);

        if (SerialNumber.Length < NumberLength) throw new FormatException(WrongFormat);

        SerialNumber = number;
    }
}