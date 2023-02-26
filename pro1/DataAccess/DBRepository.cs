using Models;
using DataAccess;
using System.Data.SqlClient;
using Serilog;
namespace DataAccess;

public class DBRepository : IRepository
{
    
    public List<Account> GetAllAccounts()
    {
        List<Account> allAccounts = new();

        SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        
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
            // Console.WriteLine("Id: {0} ", (int) reader["Id"]);
            // Console.WriteLine("Username: {0}", (string) reader["Username"]);
            // Console.WriteLine("Password: {0}", (string) reader["UserPassword"]);
            // Console.WriteLine("Role: {0}", (string) reader["UserRole"]);
        }
        

        return allAccounts;
    }

    public Account CreateNewLog(Account accountToCreate)
    {
        // try{
            using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
            conn.Open();

            using SqlCommand cmd = new SqlCommand("INSERT INTO Accounts(Username, UserPassword, UserRole) OUTPUT INSERTED.Id Values (@uName, @uPassword, @uRole)", conn);
            cmd.Parameters.AddWithValue("@uName", accountToCreate.Username);
            cmd.Parameters.AddWithValue("@uPassword", accountToCreate.Password);
            cmd.Parameters.AddWithValue("@uRole", accountToCreate.Role);

            int createdId = (int) cmd.ExecuteScalar();

            accountToCreate.Id = createdId;

            return accountToCreate;
        // }
        // catch (SqlException ex) {
        //     Log.Warning("Caught SQL Exception trying to create new account {ex}", ex);
        //     throw ex;
        // }
    }
}

