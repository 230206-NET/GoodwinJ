//Title of app
Console.WriteLine("Budget App to track expenses");

//Get initial budget from user
Console.WriteLine("Enter your initial budget:");
int budget = int.Parse(Console.ReadLine()!);
int remainder = budget;

//Get number of expenses from user
Console.WriteLine("How many expenses do you have?");
int numExpenses = int.Parse(Console.ReadLine()!);

//set up expense array and counter
Task[] expenseArr = new Task[numExpenses];
int expenseCounter = 0;

while(true) {
    
    //Get expense description from user
    Console.WriteLine("Input Expense Description:");
    string inputExpense = Console.ReadLine()!;
    Task expenseToCreate = new Task();
    expenseToCreate.Description = inputExpense;
    if(expenseCounter == expenseArr.Length) {
        expenseArr = ResizeArray(expenseArr);
    }

    //Get expense amount from user
    Console.WriteLine("Input Expense Amount");
    expenseToCreate.Amount = Console.ReadLine()!;

    //populate array with expense description and amount
    expenseArr[expenseCounter] = expenseToCreate;

    expenseCounter++;

    //ask user if there are more expenses to add
    Console.WriteLine("Add another expense?");
    string response = Console.ReadLine()!;
    if(response == "n") {
       break;
    }
}

//Method to extend array if necessary
Task[] ResizeArray(Task[] arrToResize) {
    Task[] newArr = new Task[arrToResize.Length * 2];
    for(int i = 0; i < arrToResize.Length; i++) {
        newArr[i] = arrToResize[i];
    }
    return newArr;
}

//Print all expense descriptions and their amounts
for(int i = 0; i < expenseArr.Length; i++) {
    Console.WriteLine("Description: {0}, Amount: {1}", expenseArr[i].Description, expenseArr[i].Amount);
}

//Print the remaining budget
for (int i = 0; i < expenseArr.Length; i++){
    int price = int.Parse(expenseArr[i].Amount);
    remainder = remainder - price;
}

Console.WriteLine("Remaining Amount:" + remainder);

public record Task
{
    public string Description { get; set; } = "";
    public string Amount { get; set; } = "";
}