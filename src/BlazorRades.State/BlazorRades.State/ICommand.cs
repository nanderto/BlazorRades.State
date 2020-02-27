using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State
{
    public interface ICommand
    {
        Task<bool> ExecuteAsync();

        Func<bool> Action { get; set; }
    }

    public class CountCommand : ICommand
    {
        public Func<bool> Action { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            return await Task.Run<bool>(Action);
        }
    }

    public class ComandService : StateService, IComandService
    {
        public async Task<bool> AddCommandAsync(ICommand command)
        {
            try
            {
                //command.Action.GetType();
                this.AddOrReplace<ICommand>(command.GetType().FullName, command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "YYYY");
                return false;
            }

            return true;
        }

        public async Task<bool> ExecuteCommandAsync(object command)
        {
            try
            {
                //command.Action.GetType();
                var retrievedCommand = this.Get<ICommand>(command.GetType().FullName);
                return await retrievedCommand.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "ZZZZ");
                return false;
            }
        }
    }
}
