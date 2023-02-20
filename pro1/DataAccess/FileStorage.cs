using System.Text.Json;
using Models;

namespace DataAccess;

public class FileStorage
{
    private const string _filepath = "../DataAccess/AccountLog.json";
    public FileStorage() {

        bool fileExists = File.Exists(_filepath);

        if(!fileExists)
        {
            var fs = File.Create(_filepath);
            fs.Close();
        }
    }

    public List<Account> GetAllAccounts() {
        string fileContent = File.ReadAllText(_filepath);
        return JsonSerializer.Deserialize<List<Account>>(fileContent);
    }

    public void CreateNewLog(Account accountToCreate)
    {
        List<Account> accounts = GetAllAccounts();
        accounts.Add(accountToCreate);

        string content = JsonSerializer.Serialize(accounts);
        File.WriteAllText(_filepath, content);
    }

    
}
