using Models;

public interface IIIRepository
{
    List<ReimbursementTicket> GetAllAnalyzedTickets();

    ReimbursementTicket CreateNewAnalyzedTicketLog(ReimbursementTicket analyzedTicketToCreate);
}