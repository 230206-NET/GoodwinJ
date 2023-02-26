using System.Text.Json;
using Models;
using Serilog;

namespace DataAccess;

public class FileStorage : IRepository
{
    private const string _filepath = "../DataAccess/AccountLog.json";
    public FileStorage() {

        Log.Information("Instantiating File Storage Class");
        bool fileExists = File.Exists(_filepath);

        if(!fileExists)
        {
            var fs = File.Create(_filepath);
            fs.Close();
        }
    }

    public List<Account> GetAllAccounts() {
        Log.Information("File Storage: Retrieving all accounts");
        string fileContent = File.ReadAllText(_filepath);
        return JsonSerializer.Deserialize<List<Account>>(fileContent);
    }

    public Account CreateNewLog(Account accountToCreate)
    {
        Log.Information("File Storage: creating a new account");
        
        List<Account> accounts = GetAllAccounts();
        accounts.Add(accountToCreate);

        string content = JsonSerializer.Serialize(accounts);
        File.WriteAllText(_filepath, content);
        return accountToCreate;
    }

    
}
