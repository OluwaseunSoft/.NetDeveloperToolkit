using System.Text.Json;
using CommandAPI.Models;
using StackExchange.Redis;

namespace CommandAPI.Data
{
    public class RedisCommandRepo : ICommandRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisCommandRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public async Task CreateCommandAsync(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            var db = _redis.GetDatabase();
            var serialCommand = JsonSerializer.Serialize(cmd);
            await db.HashSetAsync($"commands", new HashEntry[]
            {new HashEntry(cmd.CommandId, serialCommand)});
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Command>> GetAllCommandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Command?> GetCommandByIdAsync(string commandId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            System.Console.WriteLine("--> SavechangesAsync in RedisCommandRepo called redundantly...");
            // throw new NotImplementedException();
            await Task.CompletedTask;
        }
    }
}