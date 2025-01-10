using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            Random number = new Random();
            int magicNumber = number.Next(1, 101);

            int attempts = 0;
            bool guessed = false;

            Console.WriteLine("Welcome to the magic number game! ");

            while (!guessed)
            {
                Console.Write("What is your guess? ");
                string answer = Console.ReadLine();
                int attempt = int.Parse(answer);

                if (int.TryParse(answer, out attempt))
                {
                    attempts++;

                    if (attempt == magicNumber)
                    {
                        Console.WriteLine($"You guessed it in {attempts} attempts!");
                        guessed = true;
                    }
                    else if (attempt < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else
                    {
                        Console.WriteLine("Lower");
                    }
                
                }
                else
                {
                    Console.WriteLine("Please introduce a valid number. ");
                }

            }

            Console.WriteLine("Do you want to play again? (Yes/No)");
            string decision = Console.ReadLine();
            if (decision.ToLower() != "yes")
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for play, see you soon!");

    }
}