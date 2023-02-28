using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class SqlCommandRepo : ICommandRepo
    {
        public Task CreateCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Command>> GetAllCommandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Command> GetCommandByIdAsync(string commandId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}