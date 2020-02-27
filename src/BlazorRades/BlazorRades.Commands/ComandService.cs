// <copyright file="ComandService.cs" company="Noel Anderton">
// Copyright (c) 2020 Noel Anderton. All rights reserved.
// </copyright>

namespace BlazorRades.State
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ComandService" />
    /// </summary>
    public class ComandService : StateService, IComandService
    {
        public ComandService(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public async Task<bool> AddCommandAsync(ICommand command)
        {
            try
            {
                this.Add<ICommand>(command.GetType().FullName, command);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                return false;
            }

            return true;
        }

        public async Task<bool> ExecuteAllCommandAsync(object command)
        {
            try
            {
                bool result = true;
                var retrievedCommand = this.GetAll<ICommand>(command.GetType().FullName);
                foreach (var item in retrievedCommand)
                {
                    try
                    {
                        result = await item.ExecuteAsync();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex.Message, ex);
                        result = false;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
