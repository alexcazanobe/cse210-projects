using System;

public class ReflectionActivity : Activity
{
    private static readonly string[] _prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] _questions = 
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _remainingQuestions = new List<string>();
    private static Random _random = new Random();
    public ReflectionActivity() :base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {

    }

    public override void Run()
    {
        DisplayStartingMessage();

       string selectedPrompt =  GetRandomPrompt();
       Console.WriteLine(selectedPrompt);

       Console.WriteLine("\nPress Enter when you are ready to reflect");
       Console.ReadLine();

       _remainingQuestions = new List<string>(_questions);
       ShuffleQuestions();

       int timeSpent = 0;

       while (timeSpent < _duration && _remainingQuestions.Count > 0)
       {
        string currentQuestion = _remainingQuestions[0];
        _remainingQuestions.RemoveAt(0);

        Console.WriteLine(currentQuestion);
        ShowSpinner(7);

        timeSpent += 7;
       }

       DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Length)];
    }

   private void ShuffleQuestions()
   {
    Random rng = new Random();
    int n = _remainingQuestions.Count;
    while (n > 1)
    {
        n--;
        int k = rng.Next(n + 1);
        string value = _remainingQuestions[k];
        _remainingQuestions[k] = _remainingQuestions[n];
        _remainingQuestions[n] = value;
    }
   }
}