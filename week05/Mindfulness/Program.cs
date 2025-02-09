using System;

class Program
{
    
    static int breathCount = 0;
    static int reflectionCount = 0;
    static int listingCount = 0;

    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();

            Console.WriteLine("Select an activity to begin: ");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathCount++; 
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    reflectionCount++; 
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++; 
                    break;

                case "4":
                    keepRunning = false;
                    Console.WriteLine("Good bye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select between 1 and 4.");
                    break;
            }

            
            if (keepRunning)
            {
                ShowActivityCounts();
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }

    
    static void ShowActivityCounts()
    {
        Console.WriteLine("\nActivity Counts:");
        Console.WriteLine($"Breathing Activity completed {breathCount} times.");
        Console.WriteLine($"Reflection Activity completed {reflectionCount} times.");
        Console.WriteLine($"Listing Activity completed {listingCount} times.");
    }
}
