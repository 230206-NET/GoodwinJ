// # 230209 OOP C#

// ## Exercise: Hangman Game
// Practice string manipulation and OOP by making a hangman game console application

// - It should present the user with a word to guess (either random, or hard code)
// - Allow users to select/enter a letter
// - It should display number of letters as blank spaces
// - If the user guesses the letter correctly, it should fill in those blank spaces
// - It should draw the hangman, or at the very least have a limited number of tries
// - It should validate the user input that it is an alphabet (and not a special character, whitespace, number, etc.)
// - If the user guesses the word correctly, it should end the game ("you got it, congrats!")
// - If the user makes too many incorrect guesses, it also should end the game ("whomp whomp.. perhaps next time")

// 8: Jacob Goodwin, Samuel Perrino

Console.WriteLine("Hangman");

string chars = "stove";
char[] word = {'_', '_', '_', '_', '_'};  

string word1 = new string(word);

Console.WriteLine("Word:");
Console.WriteLine(word1);

bool end = true;
int counter = 0;
int integer;

guessAgain:

if(word1.CompareTo("stove")==0){
    Console.WriteLine("Congratulations!");
    end = false;
    }

if(counter == 6){
    Console.WriteLine("You lose");
    end = false;
}

string guess = " ";

if(end) {
Console.WriteLine("Guess a letter");

 guess = Console.ReadLine()!;
}

bool parseSuccess = int.TryParse(guess, out integer);

if(end) {
if(string.IsNullOrWhiteSpace(guess)){
    Console.WriteLine("input value must not be empty");
    goto guessAgain;
} else if (parseSuccess){
    Console.WriteLine("input value must not be an integer");
    goto guessAgain;
}
}
while(end){
for (int i =0; i<chars.Length;i++){

       

    if(guess.CompareTo("s")==0)
     {
         word[0] = 's';
         word1 = new string(word);
         Console.WriteLine(word1);
        goto guessAgain;
     }
     else if(guess.CompareTo("t")==0)
     {
         word[1] = 't';
         word1 = new string(word);
         Console.WriteLine(word1);
         goto guessAgain;
     }
     else if(guess.CompareTo("o")==0)
     {
         word[2] = 'o';
         word1 = new string(word);
         Console.WriteLine(word1);
         goto guessAgain;
     }
     else if(guess.CompareTo("v")==0)
     {
         word[3] = 'v';
         word1 = new string(word);
         Console.WriteLine(word1);
         goto guessAgain;
     }
     else if(guess.CompareTo("e")==0)
     {
         word[4] = 'e';
         word1 = new string(word);
         Console.WriteLine(word1);
         goto guessAgain;
     } else {
        counter++;
        goto guessAgain;
     }
     
}
}



