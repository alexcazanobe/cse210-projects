using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");  

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    CreateGoal();
                    break;

                case "4":
                    RecordEvent();
                    break;
                
                case "5":
                    SaveGoals();
                    break;

                case "6":
                    LoadGoals();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to display");
            return;
        }

        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid choice. Please enter 1, 2, or 3:");
        }

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        string points = Console.ReadLine();

        Goal newGoal = null;  

        if (choice == 1)
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (choice == 2)
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (choice == 3)
        {
            Console.Write("Enter target times: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal added successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available");
            return;
        }

        Console.WriteLine("Select a goal to record an event");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the goal number: ");
        int goalIndex;
        while (!int.TryParse(Console.ReadLine(), out goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid selection. Please enter a valid goal number.");
        }

        Goal selectedGoal = _goals[goalIndex - 1];
        selectedGoal.RecordEvent();

        if (int.TryParse(selectedGoal.GetPoints(), out int points))
        {
            _score += points;
        }
        else 
        {
            Console.WriteLine("Error: Invalid point value.");
        }

        Console.WriteLine("Event recorded successfully!");
    }

    public void SaveGoals()
    {
        Console.WriteLine("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt";
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }

 public void LoadGoals()
{
    Console.WriteLine("Enter the filename to load goals: ");
    string filename = Console.ReadLine();
    if (!filename.EndsWith(".txt"))
    {
        filename += ".txt";
    }

    if (!File.Exists(filename))
    {
        Console.WriteLine("No saved goals found");
        return;
    }

    _goals.Clear();
    string[] lines = File.ReadAllLines(filename);

    if (lines.Length == 0)
    {
        Console.WriteLine("The file is empty.");
        return;
    }

    try
    {
        _score = int.Parse(lines[0]);
        Console.WriteLine($"Loaded score: {_score}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: The first line of the file must be an integer representing the score.");
        return;
    }

    for (int i = 1; i < lines.Length; i++)
    {
        string[] parts = lines[i].Split('|');
        if (parts.Length < 4)
        {
            Console.WriteLine($"Error: Invalid format in line {i + 1}");
            continue;
        }

        string type = parts[0];
        string name = parts[1];
        string description = parts[2];
        string points = parts[3];

        Goal newGoal = null;

        if (type == "SimpleGoal")
        {
            bool isComplete = parts.Length > 4 && parts[4] == "[ X ]";
            newGoal = new SimpleGoal(name, description, points);
            ((SimpleGoal)newGoal).SetCompletionStatus(isComplete);
            Console.WriteLine($"Loaded SimpleGoal: {name}");
        }
        else if (type == "EternalGoal")
        {
            newGoal = new EternalGoal(name, description, points);
            Console.WriteLine($"Loaded EternalGoal: {name}");
        }
        else if (type == "ChecklistGoal")
        {
            if (parts.Length < 7)
            {
                Console.WriteLine($"Error: Invalid format for ChecklistGoal in line {i + 1}");
                continue;
            }
            string[] amountCompletedParts = parts[4].Split('/');
            int amountCompleted = int.Parse(amountCompletedParts[0]);
            int target = int.Parse(amountCompletedParts[1]);
            int bonus = int.Parse(parts[5]);
            newGoal = new ChecklistGoal(name, description, points, target, bonus);
            ((ChecklistGoal)newGoal).SetAmountCompleted(amountCompleted);
            Console.WriteLine($"Loaded ChecklistGoal: {name}");
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Added goal: {newGoal.GetDetailsString()}");
        }
    }

    Console.WriteLine("Goals loaded successfully!");
}

}