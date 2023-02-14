using FirstDotNet;
using FizzBuzz;

while(true) {
Console.WriteLine("Week One Portfolio: ");
Console.WriteLine("Pick which app you would like to run: ");
Console.WriteLine("[1]: First DotNet");
Console.WriteLine("[2]: Coin Flipper");
Console.WriteLine("[3]: Hot or Cold");
Console.WriteLine("[4]: FizzBuzz");
Console.WriteLine("[5]: ToDo App");
Console.WriteLine("[6]: Budget App");
Console.WriteLine("[x]: Exit");
string? input = Console.ReadLine();

if(input!= null) {

    switch(input){
        case "1":
             new FirstDotNet.MainMenu().Start();
        break;
        case "2":
            Console.WriteLine("Going to run coin flipper");
        break;
        case "3":
            Console.WriteLine("Going to run hot or cold");
        break;
        case "4":
            new FizzBuzz.MainMenu().Start();
        break;
        case "5":
            Console.WriteLine("Going to run ToDo App");
        break;
        case "6":
            Console.WriteLine("Going to run Budget App");
        break;
        case "x":
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Unrecognized input, please try again.");
        break;

    }
}
}