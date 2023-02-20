using System.Text.Json;
using Models;

namespace DataAccess;

public class TicketFileStorage
{
    private const string _filepath = "../DataAccess/TicketLog.json";
    public TicketFileStorage() {

        bool fileExists = File.Exists(_filepath);

        if(!fileExists)
        {
            var fs = File.Create(_filepath);
            fs.Close();
        }
    }

    public List<ReimbursementTicket> GetAllTickets() {
        string fileContent = File.ReadAllText(_filepath);
        return JsonSerializer.Deserialize<List<ReimbursementTicket>>(fileContent);
    }

    public void CreateNewTicketLog(ReimbursementTicket ticketToCreate)
    {
        List<ReimbursementTicket> tickets = GetAllTickets();
        tickets.Add(ticketToCreate);

        string content = JsonSerializer.Serialize(tickets);
        File.WriteAllText(_filepath, content);
    }
}