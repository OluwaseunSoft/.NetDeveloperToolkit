namespace DiApi.Data
{
    public class SqlDataRepo : IDataRepo
    {
        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("--> Getting Data From Sql DB");
            Console.ResetColor();
            return("Sql data from Db");
        }
    }
}