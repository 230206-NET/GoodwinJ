
public class MainMenu
{
    string ans = "";
    string input = "";
    string outcome = "";
    int cpu=0, player=0;
    Random rand = new Random();
    int cpuChoice;
    string[] strs = {"rock", "paper", "scissors"};


    private void cpuMakeChoice(){
        cpuChoice = rand.Next(1, 4);
    }

    private void playerMakeChoice(){
        input = Console.ReadLine().ToLower();
    }

    private void selectWinner(){
        switch (input){
            case "rock":
                switch(cpuChoice){
                    case 1:
                        outcome = "Tie!";
                        break;
                    case 2:
                        outcome = "You lose!";
                        cpu += 1;
                        break;
                    case 3:
                        outcome = "You Win!";
                        player += 1;
                        break;
                }
                break;
            case "paper":
                switch(cpuChoice){
                    case 1:
                        outcome = "You Win!";
                        player += 1;
                        break;
                    case 2:
                        outcome = "Tie!";
                        break;
                    case 3:
                        outcome = "You lose!";
                        cpu += 1;
                        break;
                }
                break;
            case "scissors":
                switch(cpuChoice){
                    case 1:
                        outcome = "You lose!";
                        cpu += 1;
                        break;
                    case 2:
                        outcome = "You Win!";
                        player += 1;
                        break;
                    case 3:
                        outcome = "Tie!";
                        break;
                }
                break;
            default:
                outcome = "it appears you did not pick rock paper or scissors\ncpu wins on a technicality";
                break;
        }
    }

    public void Start(){
        while (true)
        {
            cpuMakeChoice();
            Console.WriteLine("Enter your choice, rock paper or scissors");
            playerMakeChoice();
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