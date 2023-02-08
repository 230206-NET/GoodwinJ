Console.WriteLine("Budget App to track expenses");

Console.WriteLine("Enter your initial budget:");
int budget = int.Parse(Console.ReadLine()!);
int remainder = budget;

Console.WriteLine("How many expenses do you have?");
int numExpenses = int.Parse(Console.ReadLine()!);

Task[] expenseArr = new Task[numExpenses];
int expenseCounter = 0;

while(true) {
    Console.WriteLine("Input Expense Description:");
    string inputExpense = Console.ReadLine()!;
    Task expenseToCreate = new Task();
    expenseToCreate.Description = inputExpense;
    if(expenseCounter == expenseArr.Length) {
        expenseArr = ResizeArray(expenseArr);
    }
    Console.WriteLine("Input Expense Amount");
    expenseToCreate.Amount = Console.ReadLine()!;

    expenseArr[expenseCounter] = expenseToCreate;

    expenseCounter++;
    Console.WriteLine("Add another expense?");
    string response = Console.ReadLine()!;
    if(response == "n") {
       break;
    }
}

Task[] ResizeArray(Task[] arrToResize) {
    Task[] newArr = new Task[arrToResize.Length * 2];
    for(int i = 0; i < arrToResize.Length; i++) {
        newArr[i] = arrToResize[i];
    }
    return newArr;
}

for(int i = 0; i < expenseArr.Length; i++) {
    Console.WriteLine("Description: {0}, Amount: {1}", expenseArr[i].Description, expenseArr[i].Amount);
}

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