using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

 public class Product
{
    private string name;
    private string productId;
    private double price;

    private int quantity;

    public string Name 
    {
        get {return name;}
        set {name = value;}
    }

    public string ProductId{
        get { return productId;}
        set { productId = value;}
    }

    public double Price
    {
        get {return price;}
        set {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative");
            price = value; 
        }
    }

    public int  Quantity
    {
        get {return quantity;}
        set 
        {
            if (value < 0 )
               throw new ArgumentException("Quantity cannot be negative");
            quantity = value;
        }   
    }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }

}