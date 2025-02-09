using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"\nStarting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

    }

    public void DisplayEndingMessage()
    {
        Console.Clear();
        Console.WriteLine("\n Good job!");
        Console.WriteLine($"You have completed {_name} for {_duration} seconds");
        ShowSpinner(3);

        Console.Clear();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = {"\\", "|", "/", "-"};
        int i = 0;

        for (int j = 0; j < seconds; j++)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft -1, Console.CursorTop);
            i = (i + 1) % spinner.Length;
        }
       
    }

    protected void ShowCountDown(string message, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{message} {i}  ");
            Thread.Sleep(1000);
        }
        Console.Write("\r" + new string(' ', message.Length + 4) + "\r");
        
    }

    public abstract void Run();
}