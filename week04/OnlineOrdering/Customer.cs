using System;
using System.Runtime.CompilerServices;

public class Customer
{
    private string name;
    private Address address;

    public String Name
    {
        get{return name;}
        set{name = value;}
    }

    public Address Address
    {
        get{return address;}
        set{address = value;}
    }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUsa()
    {
        return Address.IsInUsa();
    }
}