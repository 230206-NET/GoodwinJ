using Models;
using DataAccess;

namespace Services;
public class AccountService
{
    private readonly IRepository _repo;
    public AccountService(IRepository repo) {
        _repo = repo;
    }


    public List<Account> GetAllAccounts() 
    {
        return _repo.GetAllAccounts();
    }

    public void CreateNewLog(Account accountToCreate) {
            _repo.CreateNewLog(accountToCreate);
    }

    public List<Account> Login(string username, string password, string role) {
        List<Account> allAccounts = GetAllAccounts();
        List<Account> match = new();
        foreach(Account ac in allAccounts) {
            if(ac.Username == username&&ac.Password == password&&ac.Role == role){
                match.Add(ac);
                break;
            }
        }
        return match;
    }
}
