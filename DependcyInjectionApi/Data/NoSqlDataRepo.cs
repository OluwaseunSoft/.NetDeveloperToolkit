namespace DiApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {

        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("--> Getting Data From NoSql DB");
            Console.ResetColor();
            return ("NoSql data from Db");
        }
    }
}