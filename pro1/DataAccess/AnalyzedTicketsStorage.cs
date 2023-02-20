using System.Text.Json;
using Models;

namespace DataAccess;

public class AnalyzedTicketsStorage
{
    private const string _filepath = "../DataAccess/AnalyzedTicketLog.json";
    public AnalyzedTicketsStorage() {

        bool fileExists = File.Exists(_filepath);

        if(!fileExists)
        {
            var fs = File.Create(_filepath);
            fs.Close();
        }
    }

    public List<ReimbursementTicket> GetAllAnalyzedTickets() {
        string fileContent = File.ReadAllText(_filepath);
        return JsonSerializer.Deserialize<List<ReimbursementTicket>>(fileContent);
    }

    public void CreateNewAnalyzedTicketLog(ReimbursementTicket ticketToCreate)
    {
        List<ReimbursementTicket> tickets = GetAllAnalyzedTickets();
        tickets.Add(ticketToCreate);

        string content = JsonSerializer.Serialize(tickets);
        File.WriteAllText(_filepath, content);
    }
}