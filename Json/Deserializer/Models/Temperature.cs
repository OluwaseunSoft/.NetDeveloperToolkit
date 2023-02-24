// Generated by https://quicktype.io

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
   

    public partial class Temperature
    {
      
        public DateTimeOffset Date { get; set; }

      
        public long TemperatureC { get; set; }

       
        public string Summary { get; set; }

        
        public long TemperatureF { get; set; }
    }

    public partial class Temperature
    {
        public static Temperature FromJson(string json) => JsonConvert.DeserializeObject<Temperature>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Temperature self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
