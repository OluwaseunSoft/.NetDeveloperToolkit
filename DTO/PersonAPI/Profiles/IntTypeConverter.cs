using AutoMapper;

namespace PersonAPI.Profiles
{
    public class IntTypeConverter : ITypeConverter<string, int>
    {
        public int Convert(string source, int destination, ResolutionContext context)
        {
            var convertedInt = 1;
            try
            {
                convertedInt = System.Convert.ToInt32(source);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"We have the following error --> {ex.Message}");
            }
            return convertedInt;
        }
    }
}