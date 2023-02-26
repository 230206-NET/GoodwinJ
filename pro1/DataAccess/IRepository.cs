using Models;

public interface IRepository
{
    List<Account> GetAllAccounts();

    Account CreateNewLog(Account accountToCreate);
}