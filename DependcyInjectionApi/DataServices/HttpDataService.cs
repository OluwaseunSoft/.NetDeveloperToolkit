namespace DiApi.DataServices
{
    public class HttpDataService : IDataService
    {
        public string GetProductData(string url)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("--> Getting Product Data...");
            Console.ResetColor();
            return "Some PRODUCT Data...";
        }
    }
}