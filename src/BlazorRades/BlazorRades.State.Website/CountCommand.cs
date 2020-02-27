using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State.Website
{
    public class CountCommand : ICommand
    {
        public Func<bool> Action { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            return await Task.Run<bool>(Action);
        }
    }
}
