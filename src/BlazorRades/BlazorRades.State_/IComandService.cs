using System.Threading.Tasks;

namespace BlazorRades.State
{
    public interface IComandService
    {
        Task<bool> AddCommandAsync(ICommand command);
        Task<bool> ExecuteAllCommandAsync(object command);
    }
}