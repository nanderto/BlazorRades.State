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
}
