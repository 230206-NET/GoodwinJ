using System;

namespace HotOrCold
{
	public class HOC
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hot or Cold Guessing Game");

			var rand = new Random();
			int target = rand.Next(21); //generate a random number between 0 and 20

			bool loop = true;
			int i = 1;
			while (loop && i < 5)
			{
				Console.WriteLine("Please guess a number between 0 and 20: ");
				int guess = Int32.Parse(Console.ReadLine());
			
				if (guess == target)
				{
					Console.WriteLine("Congratulations, you guessed it!");
					loop = false;
				}
				else if (guess > target)
				{
					Console.WriteLine("OOPS! That was too high!");
					i++;
				}
				else
				{
					Console.WriteLine("Oh no! Too low!");
					i++;
				}
			}
			if (i == 5)
			{
				Console.WriteLine("Out of guesses.");
			}
		}
	}
}
