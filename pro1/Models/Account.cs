using Models.LengthException;
using Models.RoleException;

namespace Models;

public class Account
{
    private string _userName = "";
    public string Username { 
        get
        {
            return _userName;
        } 
        set
        {
            if(value.Length >= 20)
            {
                throw new
                ArgumentLengthException("Username must be less than 20 characters");
            }
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Name cannot be empty");
            }
            _userName = value;            
        } 
    }
    private string _password = "";
    public string Password { 
        get
        {
            return _password;
        } 
        set
        {
            if(value.Length >= 20)
            {
                throw new
                ArgumentLengthException("Password must be less than 20 characters");
            }
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Password cannot be empty");
            }
            _password = value; 
        }
    }
    private string _role = "";
    public string Role { get; set; }
    //     get
    //     {
    //         return _role;
    //     } 
    //     set
    //     {
    //         if(value != "1" && value != "2")
    //         {
    //             throw new Exception("Input must be either '1' or '2'");
    //         }else if(value == "1")
    //         {
    //             value = "Employee";
    //         } else {
    //             value = "Manager";
    //         }
    //         _role = value;
    //     }
    // }

    public override string ToString()
    {
        // StringBuilder sb = new();
        
        // sb.Append($"Username: {this.Username}\nPassword: {this.Password}\nRole: {this.Role}");
        return $"Username: {this.Username}\nPassword: {this.Password}\nRole: {this.Role}";

        // return sb.ToString();
    }
}