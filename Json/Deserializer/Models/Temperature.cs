namespace Deserializer.Models
{
    public partial class Temperature
    {
      
        public DateTimeOffset Date { get; set; }
        public long TemperatureC { get; set; }
        public string? Summary { get; set; }
        public long TemperatureF { get; set; }
    }
}
