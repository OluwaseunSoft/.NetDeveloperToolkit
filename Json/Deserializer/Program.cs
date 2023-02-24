using System.Text.Json;
using Deserializer.Models;

var opt = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

string fileName = "person.json";

string jsonString = File.ReadAllText(fileName);

Person? person = JsonSerializer.Deserialize<Person>(jsonString, opt);

System.Console.WriteLine($"The first name is: {person?.FirstName}");