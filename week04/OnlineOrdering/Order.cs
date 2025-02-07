using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;


    public List<Product> Products
    {
        get{return products;}
        set{products = value;}
    }

    public Customer Customer
    {
        get{return customer;}
        set{customer = value;}
    }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (var product in Products)
        {
            total += product.GetTotalCost();
        }

        if (Customer.IsInUsa())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name} - {product.ProductId}\n";
        }
        return label;
    }


    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.GetFullAddress()}";
    }
}