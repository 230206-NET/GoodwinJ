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
        // try
        // {
            _repo.CreateNewLog(accountToCreate);
        // }
        // catch (SqlException)
        // {
        //     throw;
        // }
    }
}
