using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State
{
    public interface ICommand
    {
        Task<bool> ExecuteAsync();

        Action Action { get; set; }
    }

    public class TestCommand : ICommand
    {
        public Action Action { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            return ((bool)await Action.DynamicInvoke());
        }
    }

    public class ComandService : StateService
    {
        public async Task<bool> AddCommandAsync(ICommand command)
        {
            try
            {
                command.Action.GetType();
                this.AddOrUpdate<ICommand>(command.GetType().FullName, command);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
