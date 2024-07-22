namespace MethodName.CleanCode_ExampleTask21_27;

public partial class CleanCode
{
    private const int SeriesAndNumberLength = 10;
    private const string EnterPassportSeriesAndNumber = "Введите серию и номер паспорта";
    private const string WrongFormat = "Неверный формат серии или номера паспорта";
    private const string FileNotFound = $"Файл {DataBaseFileName} не найден. Положите файл в папку вместе с exe.";
    private const string Approved = "ПРЕДОСТАВЛЕН";
    private const string NotApproved = "НЕ ПРЕДОСТАВЛЯЛСЯ";
    private const string DataBaseFileName = "db.sqlite";

    private string GetPassportQuery(string hash) => $"select * from passports where num='{hash}' limit 1;";

    private string GetPassportNotFoundMessage(string passport)
        => $"Паспорт «{passport}» в списке участников дистанционного голосования НЕ НАЙДЕН";

    private string GetAccessIsMessage(string passport)
        => $"По паспорту «{passport}» доступ к бюллетеню на дистанционном электронном голосовании";

    private string GetAccessIsApprovedMessage(string passport) => GetAccessIsMessage(passport) + Approved;
    private string GetAccessIsNotApprovedMessage(string passport) => GetAccessIsMessage(passport) + NotApproved;
    
}