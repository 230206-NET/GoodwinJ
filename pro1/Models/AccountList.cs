namespace Models;

public class AccountList
{
    public AccountList() {
        Accounts = new List<Account>();
    }
    public List<Account> Accounts { get; set; }
}