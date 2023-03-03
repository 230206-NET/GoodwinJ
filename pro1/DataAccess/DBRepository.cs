using Models;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using Serilog;
namespace DataAccess;

public class DBRepository : IRepository
{
    private readonly string _connectionString;
    public DBRepository(string connectionString) {
        _connectionString =  connectionString;
    }
    
    public List<Account> GetAllAccounts()
    {
        List<Account> allAccounts = new();

        SqlConnection connection = new SqlConnection(_connectionString);
        
        connection.Open();
        
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts", connection);
        using SqlDataReader reader = cmd.ExecuteReader();

       
        while(reader.Read()) {
            allAccounts.Add(new Account {
                Id = (int) reader["Id"],
                Username = (string) reader["Username"],
                Password = (string) reader["UserPassword"],
                Role = (string) reader["UserRole"]
            });
        }
        

        return allAccounts;
    }

    public Account CreateNewLog(Account accountToCreate)
    {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand("INSERT INTO Accounts(Username, UserPassword, UserRole) OUTPUT INSERTED.Id Values (@uName, @uPassword, @uRole)", conn);
            cmd.Parameters.AddWithValue("@uName", accountToCreate.Username);
            cmd.Parameters.AddWithValue("@uPassword", accountToCreate.Password);
            cmd.Parameters.AddWithValue("@uRole", accountToCreate.Role);

            int createdId = (int) cmd.ExecuteScalar();

            accountToCreate.Id = createdId;

            return accountToCreate;
    }

    // public List<Account> Login(string username, string password, string role) {
    //         DataSet accountSet = new DataSet();
    //         List<Account> accountList = new();
    //         SqlDataAdapter accountAdapter = new SqlDataAdapter("SELECT * FROM Accounts Where Username = '@uName' AND UserPassword = '@uPassword' AND UserRole = '@uRole'", _connectionString);
    //         accountAdapter.SelectCommand.Parameters.AddWithValue("@uName", username);
    //         accountAdapter.SelectCommand.Parameters.AddWithValue("@uPassword", password);
    //         accountAdapter.SelectCommand.Parameters.AddWithValue("@uRole", role);

    //         accountAdapter.Fill(accountSet, "accountTable");

    //         DataTable? accountTable = accountSet.Tables["accountTable"];

    //         if(accountTable != null) {
    //             foreach(DataRow row in accountTable.Rows) {
    //                 accountList.Add(new Account{
    //                     Id = (int) row["Id"],
    //                     Username = (string) row["Username"],
    //                     Password = (string) row["UserPassword"],
    //                     Role = (string) row["UserRole"]
    //                 });
    //             }
    //         }
    //         return accountList;
    // }
}

public class DBRepository1 : IIRepository
{
    private readonly string _connectionString;
    public DBRepository1(string connectionString) {
        _connectionString =  connectionString;
    }
    public List<ReimbursementTicket> GetAllTickets()
    {
        List<ReimbursementTicket> allTickets = new();

        SqlConnection connection = new SqlConnection(_connectionString);
        
        connection.Open();
        
        using SqlCommand cmd = new SqlCommand("SELECT * FROM ReimbursementTickets", connection);
        using SqlDataReader reader = cmd.ExecuteReader();

       
        while(reader.Read()) {
            allTickets.Add(new ReimbursementTicket {
                Id = (int) reader["Id"],
                Name = (string) reader["Username"],
                Title = (string) reader["Title"],
                Amount = (string) reader["Amount"],
                Description = (string) reader["TicketDescription"],
                Status = (string) reader["TicketStatus"]
            });
        }
        

        return allTickets;
    }
    public ReimbursementTicket CreateNewTicketLog(ReimbursementTicket ticketToCreate)
    {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand("INSERT INTO ReimbursementTickets(Username, Title, Amount, TicketDescription, TicketStatus) OUTPUT INSERTED.Id Values (@uName, @tTitle, @tAmount, @tDescription, @tStatus)", conn);
            cmd.Parameters.AddWithValue("@uName", ticketToCreate.Name);
            cmd.Parameters.AddWithValue("@tTitle", ticketToCreate.Title);
            cmd.Parameters.AddWithValue("@tAmount", ticketToCreate.Amount);
            cmd.Parameters.AddWithValue("@tDescription", ticketToCreate.Description);
            cmd.Parameters.AddWithValue("@tStatus", "pending");

            int createdId = (int) cmd.ExecuteScalar();

            ticketToCreate.Id = createdId;

            return ticketToCreate;
    }

    public ReimbursementTicket UpdateTicketLog(ReimbursementTicket ticketToUpdate)
    {
        using SqlConnection conn = new SqlConnection(_connectionString);

        using  (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "UPDATE ReimbursementTickets SET TicketStatus = @tStatus Where Id = @tId";
            cmd.Parameters.AddWithValue("@tId", ticketToUpdate.Id);
            cmd.Parameters.AddWithValue("@tStatus", ticketToUpdate.Status);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        return ticketToUpdate;
    }
}