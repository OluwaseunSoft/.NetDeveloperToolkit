using System.Text.Json;

using HttpClient client = new()
{
    BaseAddress = new Uri("https://localhost:7032")
};

var response = await client.GetAsync("/Weatherforecast");

// var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", opt);
// if (temperatures != null)
// {
//     foreach (var temp in temperatures)
//     {
//         System.Console.WriteLine($"Summary: {temp.Summary}");
//     }
// }
if (response.IsSuccessStatusCode)
{
    var jsonString = await response.Content.ReadAsStringAsync();
    using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
    {
        JsonElement root = jsonDocument.RootElement;

        System.Console.WriteLine(root.ValueKind);

        foreach(var temp in root.EnumerateArray())
        {
            System.Console.WriteLine(temp.GetProperty("summary").ToString());
        }
    }
}
else
{
    System.Console.WriteLine($"Whoops! error: Error:{response.StatusCode}");
}