using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class AccessApprovementChecker
{
    private readonly StringHashComputer _stringHashComputer = new(SHA256.Create());

    public event Action<string> EmptyTableGot;
    public event Action<string> AccessNotApproved;

    public bool IsAccessApproved(string passportNumber, string filePath)
    {
        if (passportNumber == null) throw new ArgumentNullException(nameof(passportNumber));
        if (filePath == null) throw new ArgumentNullException(nameof(filePath));
        
        var dataTable = GetDataTable(passportNumber, filePath);

        bool isTableEmpty = dataTable.Rows.Count <= 0;

        if (isTableEmpty == true)
            EmptyTableGot?.Invoke(
                $"Паспорт «{passportNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН");

        bool isAccessApproved = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]);

        if (isAccessApproved == false)
            AccessNotApproved?.Invoke($"По паспорту «{passportNumber}» доступ к бюллетеню" +
                                      $" на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ");

        return isAccessApproved;
    }

    private DataTable GetDataTable(string passportNumber, string connectionString)
    {
        string hash = _stringHashComputer.HashString(passportNumber);
        var connection = new SQLiteConnection(connectionString);

        connection.Open();

        var getPassportCommand = new SQLiteCommand(GetPassportQuery(hash), connection);
        var sqLiteDataAdapter = new SQLiteDataAdapter(getPassportCommand);
        var dataTable = new DataTable();
        sqLiteDataAdapter.Fill(dataTable);

        connection.Close();

        return dataTable;
    }

    private string GetPassportQuery(string hash) => $"select * from passports where num='{hash}' limit 1;";
}