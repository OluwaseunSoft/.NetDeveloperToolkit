using DiApi.DataServices;

namespace DiApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {
        private readonly IServiceScopeFactory _scopeFactory;

        //private readonly IDataService _dataService;

        public NoSqlDataRepo(IServiceScopeFactory scopeFactory)
        {
            //_dataService = dataService;
            _scopeFactory = scopeFactory;
        }

        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("--> Getting Data From NoSql DB");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
                dataService.GetProductData("https://something.com/api");
                Console.ResetColor();
                return ("NoSql data from Db");
            }
        }
    }
}