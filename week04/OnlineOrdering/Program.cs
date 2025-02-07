using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("Roca 256", "Bahia Blanca", "Buenos Aires", "Argentina");
        Address address2 = new Address("123 Main St", "New York", "NY", "USA");

        Customer customer1 = new Customer("Mariana Tomasselli", address1);
        Customer customer2 = new Customer("Jake Dohaan", address2);

        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        Product product1 = new Product("Monitor", "P101", 200.00, 1);
        Product product2 = new Product("Headset", "P102", 75.00, 2);

        Product product3 = new Product("Keyboard", "P201", 50.00, 2);
        Product product4 = new Product("Mouse", "P202", 30.00,1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);


        Console.WriteLine("Order 1 Details: ");
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 2 Details: ");
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
    }
}