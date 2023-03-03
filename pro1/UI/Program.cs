using UI;
using Services;
using DataAccess;
using Serilog;


Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

try{
    Log.Information("Application Starting...");

    IRepository repo = new DBRepository();
    IIRepository repo1 = new DBRepository1();
    AccountService service = new AccountService(repo);
    TicketService service1 = new TicketService(repo1);
    MainMenu menu = new MainMenu(service, service1);
    menu.Start();
}
catch(Exception ex) {
    Log.Error("Something fatal happened, {0}", ex);
}
finally {
    Log.CloseAndFlush();
}


