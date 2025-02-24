namespace RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

public record ClientAddress
{
    public string Country { get; }
    public string City { get; }
    public string Address { get; }


    public ClientAddress(string country, string city, string address)
    {
        //powinno być sprawdzenie czy nie null itd.
        Country = country;
        City = city;
        //mozna rozbić address an street and home number
        Address = address;
    }
    
    
}