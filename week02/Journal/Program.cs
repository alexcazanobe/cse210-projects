using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3.Save the journal to a file");
            Console.WriteLine("4.Load the journal from a file");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Choose an option:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToString("yyyy-mm-dd"),
                        _promptText = prompt,
                        _entryText = entryText
                    };
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.WriteLine("Enter file name to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Entries saved.");
                    break;

                case "4":
                    Console.WriteLine("Enter file name to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Entries loaded.");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}