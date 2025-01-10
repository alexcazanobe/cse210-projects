using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please introduce your grade percent: ");
        string grade = Console.ReadLine();
        int gradePercent = int.Parse(grade);

        string letter = "";
        

        if (gradePercent >= 90)
        {
            letter = "A";
        }
        else if (gradePercent >=80)
        {
            letter = "B";
        }
        else if (gradePercent >=70)
        {
            letter = "C";
        }
        else if (gradePercent >=60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = gradePercent % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }


        Console.WriteLine($"Your grade is {letter}{sign}");  

        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations! You passed! ");
        }
        else
        {
            Console.WriteLine("You didn't pass, better luck next time!");
        }
    }
}