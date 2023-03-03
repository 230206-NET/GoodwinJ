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
            _repo.CreateNewTicketLog(ticketToCreate);
    }

    public void UpdateTicketLog(ReimbursementTicket ticketToUpdate) {
        _repo.UpdateTicketLog(ticketToUpdate);
    }

    public List<ReimbursementTicket> FindTickets(string username) {
        List<ReimbursementTicket> allTickets = GetAllTickets();
        List<ReimbursementTicket> equal = new();
        foreach(ReimbursementTicket tkt in allTickets) {
            if(tkt.Name == username){
                equal.Add(tkt);
            }
        }
        return equal;
    }
}