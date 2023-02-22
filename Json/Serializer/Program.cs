using System.Text.Json;
using Serializer.Models;


var person = new Person
{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false,
    Address = new Address
    {
        StreetName = "20 Yetunde Brown",
        City = "Lagos",
        ZipCode = "12345"
    },
    Phones = new List<Phone>()
    {
        new Phone {PhoneType = "Home", PhoneNumber = "08023354288"},
        new Phone {PhoneType = "Mobile", PhoneNumber = "08054354288"}
    }
};

var opt = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string jsonString = JsonSerializer.Serialize<Person>(person);
string fileName = "person.json";
File.WriteAllText(fileName, jsonString);
System.Console.WriteLine(File.ReadAllText(fileName));