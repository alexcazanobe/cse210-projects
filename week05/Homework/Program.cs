using System;

class Program
{
    static void Main(string[] args)
    {
        
        Assignment myAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(myAssignment.GetSummary());
        
        Console.WriteLine();
        
        MathAssignment myMathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");

        
        Console.WriteLine(myMathAssignment.GetSummary());     
        Console.WriteLine(myMathAssignment.GetHomeworkList()); 
    

        Console.WriteLine();

        WritingAssignment myWritingAssigment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(myWritingAssigment.GetSummary());
        Console.WriteLine(myWritingAssigment.GetWritingInformation());
    
    
    }
}