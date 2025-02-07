using System;

public class Address 
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;


    public string StreetAddress
    {
        get{return streetAddress;}
        set{streetAddress = value;}
    }

    public string City{
        get{return city;}
        set{city = value;}
    }

    public string State 
    {
        get{return state;}
        set{state = value;}
    }

    public string Country 
    {
        get{return country;}
        set{country = value;}
    }

    public Address (string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUsa()
    {
        return Country.ToLower() == "usa" || Country.ToLower() == "united states";
    }

    public string GetFullAddress()
    {
        return$"{StreetAddress}\n{City}, {State}\n{Country}";
    }
}