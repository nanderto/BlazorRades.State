using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorRades.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorRades.State.Tests
{
    [TestClass]
    public class ComandServiceTests
    {
        [TestMethod]
        public void AddCommandAsyncTest()
        {
            var sut = new ComandService();
            sut.AddCommandAsync()
        }
    }
}