using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using MethodName.CleanCode_ExampleTask21_27.External;
using Convert = System.Convert;

namespace MethodName.CleanCode_ExampleTask21_27;

public partial class CleanCode
{
    private readonly DataBaseFileHandler _fileHandler = new(DataBaseFileName);
    private readonly StringHashComputer _stringHashComputer = new(SHA256.Create());

    private TextBox _passportTextbox;
    private TextBox _textResult;
    private string _passportSeriesAndNumber;

    private void CheckButton_Click(object sender, EventArgs e)
    {
        _passportSeriesAndNumber = _passportTextbox.Text.Replace(" ", string.Empty);

        if (HasErrors(_passportSeriesAndNumber, _fileHandler) == true) 
            return;

        var connection = new SQLiteConnection(_fileHandler.ConnectionString);
        
        DataTable dataTable = GetDataTable(_passportSeriesAndNumber, connection);
        object? item = dataTable.Rows[0].ItemArray[1];

        connection.Open();

        if (IsTableEmpty(dataTable) == false)
            ShowAccessApprovingMessage(item);
        else
            ShowPassportNotFoundMessage();

        connection.Close();
    }

    private bool HasErrors(string passportSeriesAndNumber, DataBaseFileHandler fileHandler)
    {
        if (string.IsNullOrWhiteSpace(passportSeriesAndNumber) == true)
        {
            MessageBox.Show(EnterPassportSeriesAndNumber);
            return true;
        }

        if (passportSeriesAndNumber.Length < SeriesAndNumberLength)
        {
            _textResult.Text = WrongFormat;
            return true;
        }

        if (File.Exists(fileHandler.FilePath) == false)
        {
            MessageBox.Show(FileNotFound);
            return true;
        }

        return false;
    }

    private DataTable GetDataTable(string passportSeriesAndNumber, SQLiteConnection connection)
    {
        string hash = _stringHashComputer.HashString(passportSeriesAndNumber);
        
        var getPassportByHashCommand = new SQLiteCommand(GetPassportQuery(hash), connection);
        var sqLiteDataAdapter = new SQLiteDataAdapter(getPassportByHashCommand);
        var dataTable = new DataTable();
        sqLiteDataAdapter.Fill(dataTable);

        return dataTable;
    }

    private bool IsTableEmpty(DataTable dataTable) => dataTable.Rows.Count <= 0;

    private void ShowAccessApprovingMessage(object? item)
    {
        bool isAccessApproved = Convert.ToBoolean(item);
        string isAccessApprovedText = isAccessApproved == true ? Approved : NotApproved;
        
        string message = 
            isAccessApproved == true 
            ? GetAccessIsApprovedMessage(_passportSeriesAndNumber) 
            : GetAccessIsNotApprovedMessage(_passportSeriesAndNumber);

        _textResult.Text = message + isAccessApprovedText;
    }

    private void ShowPassportNotFoundMessage() => 
        _textResult.Text = GetPassportNotFoundMessage(_passportSeriesAndNumber);
}