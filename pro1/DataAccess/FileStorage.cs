// using System.Text.Json;
// using Models;
// using Serilog;

// namespace DataAccess;

// public class FileStorage : IRepository
// {
//     private const string _filepath = "../DataAccess/AccountLog.json";
//     public FileStorage() {

//         Log.Information("Instantiating File Storage Class");
//         bool fileExists = File.Exists(_filepath);

//         if(!fileExists)
//         {
//             var fs = File.Create(_filepath);
//             fs.Close();
//         }
//     }

//     public List<Account> GetAllAccounts() {
//         Log.Information("File Storage: Retrieving all accounts");
//         string fileContent = File.ReadAllText(_filepath);
//         return JsonSerializer.Deserialize<List<Account>>(fileContent);
//     }

//     public Account CreateNewLog(Account accountToCreate)
//     {
//         Log.Information("File Storage: creating a new account");
        
//         List<Account> accounts = GetAllAccounts();
//         accounts.Add(accountToCreate);

//         string content = JsonSerializer.Serialize(accounts);
//         File.WriteAllText(_filepath, content);
//         return accountToCreate;
//     }

    
// }

// public class TicketFileStorage : IIRepository
// { 
//     private const string _filepath = "../DataAccess/TicketLog.json";
//     public TicketFileStorage() {

//         bool fileExists = File.Exists(_filepath);

//         if(!fileExists)
//         {
//             var fs = File.Create(_filepath);
//             fs.Close();
//         }
//     }

//     public List<ReimbursementTicket> GetAllTickets() {
//         string fileContent = File.ReadAllText(_filepath);
//         return JsonSerializer.Deserialize<List<ReimbursementTicket>>(fileContent);
//     }

//     public ReimbursementTicket CreateNewTicketLog(ReimbursementTicket ticketToCreate)
//     {
//         List<ReimbursementTicket> tickets = GetAllTickets();
//         tickets.Add(ticketToCreate);

//         string content = JsonSerializer.Serialize(tickets);
//         File.WriteAllText(_filepath, content);
//         return ticketToCreate;
//     }
// }


