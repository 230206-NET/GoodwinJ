using Xunit;
using Models;
using Models.LengthException;
using Models.IntegerException;


namespace Tests;

public class AccountTests
{
    [Fact]
    public void AccountShouldCreate()
    {
        Account ac = new();

        Assert.NotNull(ac);
        Assert.NotNull(ac.Username);
        Assert.NotNull(ac.Password);
    }

    [Fact]
    public void UsernameShouldSetValidName() {
        Account ac = new();

        ac.Username = "TestName";

        Assert.Equal("TestName", ac.Username);
    }

    [Fact]
    public void UsernameLengthValidation() {
        Account ac = new();

        string invalidName = "dfghjktauwyadhiuwjnwadnakdnsjkandknaikiudwaidasnlflalnkfafnlanlsdm";
        Assert.Throws<ArgumentLengthException>(() => ac.Username = invalidName);
    }
}

public class ReimbursementTicketTests
{
    [Fact]
    public void TicketShouldCreate()
    {
        ReimbursementTicket tkt = new();
        Assert.NotNull(tkt);
        Assert.NotNull(tkt.Id);
        Assert.NotNull(tkt.Title);
        Assert.NotNull(tkt.Amount);
        Assert.NotNull(tkt.Description);
    }
    [Fact]
    public void TitleShouldSetValidName() {
        ReimbursementTicket tkt = new();

        tkt.Title = "TestName";

        Assert.Equal("TestName", tkt.Title);
    }
    [Fact]
    public void AmountIntegerValidation() {
        ReimbursementTicket tkt = new();

        string invalidAmount = "string";
        Assert.Throws<ArgumentIntegerException>(() => tkt.Amount = invalidAmount);
    }
}