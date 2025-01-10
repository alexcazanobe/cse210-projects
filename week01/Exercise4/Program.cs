using System;

class Program
{
    static void Main(string[] args)
    {
      List<int> numbers = new List<int>();
      int number = -1;
      int sum = 0;

      Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

      while (number !=0)
      {
        Console.Write("Enter number: ");
        number =int.Parse(Console.ReadLine());

        if (number != 0)
        {
            numbers.Add(number);
        }
      }

      foreach (int num in numbers)
      {
        sum += num;
      }

      Console.WriteLine($"The sum is : {sum}");

      int count = numbers.Count;
      double average = (double)sum/count;
      Console.WriteLine($"The average is {average}");

      int largest = -1;
      foreach (int num in numbers)
      {
        if (num > largest)
        {
            largest = num;
        }
      }
      Console.WriteLine($"The largest number is {largest}");

      int smallest = int.MaxValue;
      foreach (int num in numbers)
      {
        if (num > 0 && num < smallest)
        {
            smallest = num;
        }
      }
      Console.WriteLine($"The smallest number is {smallest}");

      numbers.Sort();
      Console.WriteLine("The sorted list is: ");
      foreach (int num in numbers)
      {
        Console.WriteLine(num);
      }


    }
}