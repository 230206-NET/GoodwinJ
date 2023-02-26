using Models;
using DataAccess;
using System.Data.SqlClient;
using Serilog;
namespace DataAccess;

public class DBRepository1 : IIRepository
{
    public List<ReimbursementTicket> GetAllTickets()
    {
        List<ReimbursementTicket> allTickets = new();

        SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        
        connection.Open();
        
        using SqlCommand cmd = new SqlCommand("SELECT * FROM ReimbursementTickets", connection);
        using SqlDataReader reader = cmd.ExecuteReader();

       
        while(reader.Read()) {
            allTickets.Add(new ReimbursementTicket {
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
        

        return allTickets;
    }
    public ReimbursementTicket CreateNewTicketLog(ReimbursementTicket ticketToCreate)
    {
        // try{
            using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
            conn.Open();

            using SqlCommand cmd = new SqlCommand("INSERT INTO ReimbursementTickets(Username, Title, TicketDescription, TicketStatus) OUTPUT INSERTED.Id Values (@uName, @tTitle, @tDescription, @tStatus)", conn);
            cmd.Parameters.AddWithValue("@uName", ticketToCreate.Name);
            cmd.Parameters.AddWithValue("@tTitle", ticketToCreate.Title);
            cmd.Parameters.AddWithValue("@tDescription", ticketToCreate.Description);
            cmd.Parameters.AddWithValue("@tStatus", ticketToCreate.Status);

            int createdId = (int) cmd.ExecuteScalar();

            ticketToCreate.Id = createdId;

            return ticketToCreate;
        // }
        // catch (SqlException ex) {
        //     Log.Warning("Caught SQL Exception trying to create new account {ex}", ex);
        //     throw ex;
        // }
    }
}