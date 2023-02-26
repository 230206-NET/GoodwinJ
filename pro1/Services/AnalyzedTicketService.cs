using Models;
using DataAccess;

namespace Services;
public class AnalyzedTicketService
{
    private readonly IIIRepository _repo;
    public AnalyzedTicketService(IIIRepository repo) {
        _repo = repo;
    }


    public List<ReimbursementTicket> GetAllAnalyzedTickets() 
    {
        return _repo.GetAllAnalyzedTickets();
    }

    public void CreateNewAnalyzedTicketLog(ReimbursementTicket analyzedTicketToCreate) {
        // try
        // {
            _repo.CreateNewAnalyzedTicketLog(analyzedTicketToCreate);
        // }
        // catch (SqlException)
        // {
        //     throw;
        // }
    }
}