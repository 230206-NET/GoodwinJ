using Models;
using DataAccess;
using System.Data.SqlClient;
using Serilog;
namespace DataAccess;

public class DBRepository2 : IIIRepository
{
    public List<ReimbursementTicket> GetAllAnalyzedTickets()
    {
        List<ReimbursementTicket> allAnalyzedTickets = new();

        SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        
        connection.Open();
        
        using SqlCommand cmd = new SqlCommand("SELECT * FROM AnalyzedReimbursementTickets", connection);
        using SqlDataReader reader = cmd.ExecuteReader();

       
        while(reader.Read()) {
            allAnalyzedTickets.Add(new ReimbursementTicket {
                Id = (int) reader["Id"],
                Name = (string) reader["Username"],
                Title = (string) reader["Title"],
                Description = (string) reader["TicketDescription"],
                Status = (string) reader["TicketStatus"]
            });
            // Console.WriteLine("Id: {0} ", (int) reader["Id"]);
            // Console.WriteLine("Username: {0}", (string) reader["Username"]);
            // Console.WriteLine("Password: {0}", (string) reader["UserPassword"]);
            // Console.WriteLine("Role: {0}", (string) reader["UserRole"]);
        }
        

        return allAnalyzedTickets;
    }
    public ReimbursementTicket CreateNewAnalyzedTicketLog(ReimbursementTicket analyzedTicketToCreate)
    {
        // try{
            using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
            conn.Open();

            using SqlCommand cmd = new SqlCommand("INSERT INTO AnalyzedReimbursementTickets(Username, Title, TicketDescription, TicketStatus) OUTPUT INSERTED.Id Values (@uName, @tTitle, @tDescription, @tStatus)", conn);
            cmd.Parameters.AddWithValue("@uName", analyzedTicketToCreate.Name);
            cmd.Parameters.AddWithValue("@tTitle", analyzedTicketToCreate.Title);
            cmd.Parameters.AddWithValue("@tDescription", analyzedTicketToCreate.Description);
            cmd.Parameters.AddWithValue("@tStatus", analyzedTicketToCreate.Status);

            int createdId = (int) cmd.ExecuteScalar();

            analyzedTicketToCreate.Id = createdId;

            return analyzedTicketToCreate;
        // }
        // catch (SqlException ex) {
        //     Log.Warning("Caught SQL Exception trying to create new account {ex}", ex);
        //     throw ex;
        // }
    }
}