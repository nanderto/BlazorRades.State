using System;
using System.Threading.Tasks;

namespace BlazorRades.State
{
    public class ComandService : StateService, IComandService
    {
        public async Task<bool> AddCommandAsync(ICommand command)
        {
            try
            {
                //command.Action.GetType();
                this.Add<ICommand>(command.GetType().FullName, command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "YYYY");
                return false;
            }

            return true;
        }

        public async Task<bool> ExecuteAllCommandAsync(object command)
        {
            try
            {
                bool result = false;
                var retrievedCommand = this.GetAll<ICommand>(command.GetType().FullName);
                foreach (var item in retrievedCommand)
                {
                    result = await item.ExecuteAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "ZZZZ");
                return false;
            }
        }
    }
}
