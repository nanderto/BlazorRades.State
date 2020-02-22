using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorRades.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorRades.State.Tests
{
    [TestClass]
    public class StateServiceTests
    {
        [TestMethod]
        public void AddTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage();
            sut.Add<TestMessage>("1", testMessage);
            var result = sut.Get<TestMessage>("1");
            Assert.AreEqual(testMessage, result);
            Assert.IsInstanceOfType(result, typeof(TestMessage));
        }
    }

    internal class TestMessage
    {
    }
}
