using Models;
using Models.LengthException;
using Models.RoleException;
using DataAccess;
namespace UI;

public class MainMenu
{
    List<Account> accounts = new();
    string userInput = "";
    public void Start() {
        // AccountList accounts = new AccountList();
        // List<Account> accounts = new();
        while(true){
            Console.WriteLine("Expense Reimbursement System");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[1] Log In");
            Console.WriteLine("[2] Create an account");
            Console.WriteLine("[x] Exit");
            string? input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    // Console.WriteLine("Logging in: ");
                    // string choice = "";
                    // while(true) {
                    //     Console.WriteLine("Enter [1] if your role is employee and [2] if your role is manager");
                    //     choice = Console.ReadLine();
                    //     if (choice != "1" && choice != "2")
                    //     {
                    //         Console.WriteLine("Input must be '1' or '2'");
                    //     }else if(choice == "1")
                    //     {
                    //         choice = "Employee";
                    //         break;
                    //     } else
                    //     {
                    //         choice = "Manager";
                    //         break;
                    //     }
                    // }
                    // Console.WriteLine("Username: ");
                    // string? nameInput = Console.ReadLine();
                    // Console.WriteLine("Password: ");
                    // string? passwordInput = Console.ReadLine();
                    // List<Account> log = new FileStorage().GetAllAccounts();
                    // foreach(Account ac in log)
                    // {
                    //     if(nameInput == ac.Username && passwordInput == ac.Password && choice == ac.Role){
                    //         Console.WriteLine("logged in");
                    //         break;
                    //     }                  
                    // }
                    // Console.WriteLine("No account found");
                    LogInProcess();

                break;
                case "2":
                    CreateNewAccount();
                    
                break;
                case "3":
                    List<Account> logs = new FileStorage().GetAllAccounts();
                    foreach(Account ac in logs)
                    {
                        Console.WriteLine(ac);
                    }
                    // foreach(Account ac in accounts) {
                    //     Console.WriteLine(ac);
                    // }

                break;
                case "x":
                    Environment.Exit(0);
                break;
                default:
                    Console.WriteLine("I Don't understand your input");
                break;
            }   
        }
        
    }


private void CreateNewAccount() {
    Account user = new Account();
    Console.WriteLine("Creating new account: ");
    while(true){
        Console.WriteLine("Enter [1] to create an employee account or [2] to create a manager account");
        string? choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Input must be '1' or '2'");
        }else if(choice == "1")
        {
            user.Role = "Employee";
            break;
        } else
        {
            user.Role = "Manager";
            break;
        }
    }
    while(true){
        Console.WriteLine("Username: ");
        string? nameInput = Console.ReadLine();
        try {
            user.Username = nameInput;
            break;
        }
        catch(ArgumentNullException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
        catch(ArgumentLengthException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    while(true){
        Console.WriteLine("Password: ");
        string? passwordInput = Console.ReadLine();
        try {
            user.Password = passwordInput;
            break;
        }
        catch(ArgumentNullException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
        catch(ArgumentLengthException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    Console.WriteLine("Role: {0}", user.Role);
    Console.WriteLine("Username: {0}", user.Username);
    Console.WriteLine("Password: {0}", user.Password);

    // accounts.Add(user);
    new FileStorage().CreateNewLog(user);
}

private void LogInProcess() {
    Console.WriteLine("Logging in: ");
    string choice = "";
    while(true) {
        Console.WriteLine("Enter [1] if your role is employee and [2] if your role is manager");
        choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Input must be '1' or '2'");
        }else if(choice == "1")
        {
            choice = "Employee";
            break;
        } else
        {
            choice = "Manager";
            break;
        }
    }
    Console.WriteLine("Username: ");
    userInput = Console.ReadLine();
    Console.WriteLine("Password: ");
    string? passwordInput = Console.ReadLine();
    List<Account> log = new FileStorage().GetAllAccounts();
    bool accountExists = false;
    foreach(Account ac in log)
    {
        if(userInput == ac.Username && passwordInput == ac.Password && choice == ac.Role && choice == "Employee"){
            Console.WriteLine("logged in");
            accountExists = true;
            EmployeeMenu();
            break;
        } else if(userInput == ac.Username && passwordInput == ac.Password && choice == ac.Role && choice == "Manager"){
            Console.WriteLine("logged in");
            accountExists = true;
            ManagerMenu();
            break;
        }                 
    }
    if(!accountExists){
    Console.WriteLine("No account found");
    }
}

private void EmployeeMenu() {
    Console.WriteLine("Welcome");
    while(true){
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[1] Submit a reimbursement ticket");
    Console.WriteLine("[x] Logout");
    
    string? input = Console.ReadLine();
    switch(input)
    {
        case "1":
            CreateNewTicket();
        break;
        case "x":
            return;
        break;
        default:
            Console.WriteLine("I Don't understand your input");
        break;
    }
    }    
}

private void CreateNewTicket() {
    ReimbursementTicket ticket = new ReimbursementTicket();
    Console.WriteLine("Creating new ticket");
    ticket.Name = userInput;
    while(true){
        Console.WriteLine("Title: ");
        string? titleInput = Console.ReadLine();
        try {
            ticket.Title = titleInput;
            break;
        }
        catch(ArgumentNullException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
        catch(ArgumentLengthException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    while(true){
        Console.WriteLine("Description: ");
        string? descriptionInput = Console.ReadLine();
        try {
            ticket.Description = descriptionInput;
            break;
        }
        catch(ArgumentNullException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
        catch(ArgumentLengthException ex) {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    ticket.Status = "Pending";
    Console.WriteLine("User: {0}", ticket.Name);
    Console.WriteLine("Title: {0}", ticket.Title);
    Console.WriteLine("Description: {0}", ticket.Description);
    Console.WriteLine("Status: {0}", ticket.Status);

    new TicketFileStorage().CreateNewTicketLog(ticket);
}
private void ManagerMenu() {
    Console.WriteLine("Welcome");
    while(true){
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[1] Approve/Reject a reimbursement ticket");
    Console.WriteLine("[x] Logout");
    
    string? input = Console.ReadLine();
    switch(input)
    {
        case "1":
            ticketDecision();
        break;
        case "x":
            return;
        break;
        default:
            Console.WriteLine("I Don't understand your input");
        break;
    }
    }    
}
private void ticketDecision() {
    List<ReimbursementTicket> ticketlog = new TicketFileStorage().GetAllTickets();
    List<ReimbursementTicket> analyzedticketlog = new AnalyzedTicketsStorage().GetAllAnalyzedTickets();
    bool skip = false;
    string stat = "";
    foreach(ReimbursementTicket rt in ticketlog)
    {
        skip = false;
        foreach(ReimbursementTicket art in analyzedticketlog){
            if(rt.Name == art.Name && rt.Title == art.Title && rt.Description == art.Description) {
                skip = true;
                // Console.WriteLine("Username: " + rt.Name);
                // Console.WriteLine("Title: " + rt.Title);
                // Console.WriteLine("Description: " + rt.Description);
                // Console.WriteLine("Enter [1] to approve or [2] to reject");
                // string select = Console.ReadLine();
                // if (select != "1" && select != "2")
                // {
                //     Console.WriteLine("Input must be '1' or '2'");
                // }else if(select == "1")
                // {
                //     rt.Status = "Approved";
                //     Console.WriteLine("Ticket approved");
                //     break;
                // } else
                // {
                //     rt.Status = "Rejected";
                //     Console.WriteLine("Ticket rejected");
                //     break;
                // }
            }
        }
        if(!skip) {
            Console.WriteLine("Username: " + rt.Name);
            Console.WriteLine("Title: " + rt.Title);
            Console.WriteLine("Description: " + rt.Description);
            while(true) {
                Console.WriteLine("Enter [1] to approve or [2] to reject");
                string select = Console.ReadLine();
                if (select != "1" && select != "2")
                {
                    Console.WriteLine("Input must be '1' or '2'");
                }else if(select == "1")
                {
                    stat = "Approved";
                    Console.WriteLine("Ticket approved");
                    break;
                } else
                {
                    stat = "Rejected";
                    Console.WriteLine("Ticket rejected");
                    break;
                }
            }
            ReimbursementTicket analyzedticket = new ReimbursementTicket();
            analyzedticket.Name = rt.Name;
            analyzedticket.Title = rt.Title;
            analyzedticket.Description = rt.Description;
            analyzedticket.Status = stat;
            new AnalyzedTicketsStorage().CreateNewAnalyzedTicketLog(analyzedticket);
        }       
    }
}
}