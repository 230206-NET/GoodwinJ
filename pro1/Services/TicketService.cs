using Models;
using DataAccess;

namespace Services;
public class TicketService
{
    private readonly IIRepository _repo;
    public TicketService(IIRepository repo) {
        _repo = repo;
    }


    public List<ReimbursementTicket> GetAllTickets() 
    {
        return _repo.GetAllTickets();
    }

    public void CreateNewTicketLog(ReimbursementTicket ticketToCreate) {
        // try
        // {
            _repo.CreateNewTicketLog(ticketToCreate);
        // }
        // catch (SqlException)
        // {
        //     throw;
        // }
    }
}