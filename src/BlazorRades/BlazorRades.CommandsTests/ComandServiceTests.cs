using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorRades.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BlazorRades.State.Tests
{
    [TestClass()]
    public class ComandServiceTests
    {
        [TestMethod]
        public async Task AddCommandAsyncTest()
        {
            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {
                var logger = loggerFactory.CreateLogger<ComandServiceTests>();
                var sut = new ComandService(logger);
                var testCommand = new CountCommand();
                testCommand.Action = () => { return true; };
                var result = await sut.AddCommandAsync(testCommand);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ExecuteCommandAsyncTest()
        {
            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {
                var logger = loggerFactory.CreateLogger<ComandServiceTests>();
                var sut = new ComandService(logger);
                var testCommand = new CountCommand();
                testCommand.Action = () => { return true; };
                var result = await sut.AddCommandAsync(testCommand);

                var exectedResult = await sut.ExecuteAllCommandAsync(testCommand);

                Assert.IsTrue(exectedResult);
            }
        }
    }

    public class CountCommand : ICommand
    {
        public Func<bool> Action { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            return await Task.Run<bool>(Action);
        }
    }
}