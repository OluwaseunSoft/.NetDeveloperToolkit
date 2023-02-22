using System.Text.Json;
using Serializer.Models;


var person = new Person
{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false
};

var opt = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string jsonString = JsonSerializer.Serialize<Person>(person, opt);
string fileName = "person.json";
File.WriteAllText(fileName, jsonString);
System.Console.WriteLine(File.ReadAllText(fileName));