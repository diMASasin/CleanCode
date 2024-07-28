using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace CleanCode.CleanCode_ExampleTask21_27.Presenter;

public class AccessApprovementChecker
{
    private readonly StringHashComputer _stringHashComputer = new(SHA256.Create());

    public bool IsAccessApproved(string serialNumber, string dataBaseFilePath)
    {
        if (string.IsNullOrWhiteSpace(serialNumber) == true) throw new ArgumentNullException(nameof(serialNumber));
        if (dataBaseFilePath == null) throw new ArgumentNullException(nameof(dataBaseFilePath));
        
        var dataTable = GetDataTable(serialNumber, dataBaseFilePath);

        bool isTableEmpty = dataTable.Rows.Count <= 0;

        if (isTableEmpty == true)
            throw new SqlNullValueException(
                $"Паспорт «{serialNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН");

        bool isAccessApproved = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]);

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