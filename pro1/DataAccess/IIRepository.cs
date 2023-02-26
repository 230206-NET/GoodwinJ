using Models;

public interface IIRepository
{
    List<ReimbursementTicket> GetAllTickets();

    ReimbursementTicket CreateNewTicketLog(ReimbursementTicket ticketToCreate);
}