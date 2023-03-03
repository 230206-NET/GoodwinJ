using Models;
namespace DataAccess;

public interface IRepository
{
    List<Account> GetAllAccounts();

    Account CreateNewLog(Account accountToCreate);

    // List<Account> Login(string username, string password, string role);
}

public interface IIRepository
{
    List<ReimbursementTicket> GetAllTickets();

    ReimbursementTicket CreateNewTicketLog(ReimbursementTicket ticketToCreate);

    ReimbursementTicket UpdateTicketLog(ReimbursementTicket ticketToUpdate);
}

