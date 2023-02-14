//Namespace is logical collection of types/classes/etc.
// They can span multiple files and even multiple projects
namespace FirstDotNet;

public class MainMenu {

public void Start() {

Console.WriteLine("Starting Program...");

string userInput = Console.ReadLine()!;

Console.WriteLine(userInput);

if (5>4)
{
	Console.WriteLine("Five is greater than four!");
}

if (4>5)
{
	Console.WriteLine("Four is greater than five?");
}

int balance = 0;

if (balance <= 0)
{
	Console.WriteLine("Account Balance must not have a negative balance!");
}

else 
{
	Console.WriteLine(balance);
}

Console.WriteLine("Ending Program");

}
}