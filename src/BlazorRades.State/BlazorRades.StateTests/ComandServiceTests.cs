using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorRades.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRades.State.Tests
{
    [TestClass]
    public class ComandServiceTests
    {
        [TestMethod]
        public async Task AddCommandAsyncTest()
        {
            var sut = new ComandService();
            var testCommand = new CountCommand();
            testCommand.Action = () => { return true; };
            var result = await sut.AddCommandAsync(testCommand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ExecuteCommandAsyncTest()
        {
            var sut = new ComandService();
            var testCommand = new CountCommand();
            testCommand.Action = () => { return true; };
            var result = await sut.AddCommandAsync(testCommand);

            var exectedResult = await sut.ExecuteCommandAsync(testCommand);

            Assert.IsTrue(exectedResult);
        }
    }
}