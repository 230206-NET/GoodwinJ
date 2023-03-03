using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataAccess;
using Services;
using Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, DBRepository>(ctx => new DBRepository(builder.Configuration.GetConnectionString("reimbursementticketsDB")));
builder.Services.AddScoped<IIRepository, DBRepository1>(ctx => new DBRepository1(builder.Configuration.GetConnectionString("reimbursementticketsDB")));
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TicketService>();
// builder.Configuration.getConnectionString("reimbursementticketsDB");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Welcome to the Reimbursement ticket app");

app.MapPost("/accounts", ([FromBody] Account account, AccountService service) => {
    service.CreateNewLog(account);
});

app.MapGet("/login", ([FromQuery] string? username, [FromQuery] string? password, [FromQuery] string? role, AccountService service) => {
    return service.Login(username, password, role);
});

// app.MapGet("/greet", ([FromQuery]string? name, [FromQuery] string? region) 
// => {
//     if(string.IsNullOrWhiteSpace(name)) {
//         return Results.BadRequest("Name must not be empty or white spaces");
//     }
//     else
//     {
//         return Results.Ok($"Hello {name} from {region ?? "somewhere"}!");
//     }
// });

app.MapPost("/tickets", ([FromBody] ReimbursementTicket ticket, TicketService service) => {
    service.CreateNewTicketLog(ticket);
});

app.MapGet("/ticketview", ([FromQuery] string? username, TicketService service) => {
    return service.FindTickets(username);
});

app.MapGet("/tickets", (TicketService service) => {
    return service.GetAllTickets();
});

app.MapPut("/tickets",([FromBody] ReimbursementTicket ticket, TicketService service) => {
    service.UpdateTicketLog(ticket);
});

app.MapGet("/accounts", (AccountService service) => {
    return service.GetAllAccounts();
});

app.Run();
