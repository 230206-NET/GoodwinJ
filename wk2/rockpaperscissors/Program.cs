namespace rockPaperScissors;

public class MainMenu {
    public void Start(){
        int cpuChoice;
        string ans = "";


        while (true)
        {
            cpuChoice = rpc.cpuMakeChoice();
            Console.WriteLine("Enter your choice, rock paper or scissors");
            ans = rpc.playerMakeChoice();
            selectWinner();
            Console.WriteLine(outcome);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Player wins " + player + " times");
            Console.WriteLine("System wins " + cpu + " times");
            Console.WriteLine("Cpu picked {0}", strs[cpuChoice-1]);
            Console.WriteLine("Do u want to continue(YES/NO):");
            ans = Console.ReadLine().ToUpper();
            if(ans == "NO") break;
        }
    }

}