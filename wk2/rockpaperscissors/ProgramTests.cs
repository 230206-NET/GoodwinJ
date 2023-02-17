using Xunit;
using rockPaperScissors;

namespace Tests;

public class ProgramTests {
    [Fact]
    public void negateBooleanNegates(){
        Assert.Equal(ProgramTests.negateBoolean(true), false);
    }

    private static bool negateBoolean(bool input){
        return !input;
        
    }

    [Fact]
    public void cpuChoiceValid(){
        rpc choice = new rpc();

        Assert.Equal(choice.cpuChoice, 1 || 2 || 3);
    }
}