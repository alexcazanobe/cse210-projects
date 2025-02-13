using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Red", 4.0);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 3.0, 6.0);
        shapes.Add(rectangle);

        Circle circle = new Circle ("Violet", 8.4);
        shapes.Add(circle);

        

        foreach (var shape in shapes)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}");
            
        }

    }
}