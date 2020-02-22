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
        public void AddOrUpdateTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage();
            sut.AddOrUpdate<TestMessage>("1", testMessage);
            var result = sut.Get<TestMessage>("1");
            Assert.AreEqual(testMessage, result);
            Assert.IsInstanceOfType(result, typeof(TestMessage));
        }

        [TestMethod]
        public void AddOrUpdateMultipleTypesTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage();
            sut.AddOrUpdate<TestMessage>("1", testMessage);
            var testMessage2 = new TestMessage2();
            sut.AddOrUpdate<TestMessage2>("2", testMessage2);
            var testMessage3 = new TestMessage2();
            sut.AddOrUpdate<TestMessage2>("3", testMessage3);

            var result = sut.Get<TestMessage>("1");
            Assert.AreEqual(testMessage, result);
            Assert.IsInstanceOfType(result, typeof(TestMessage));

            var result2 = sut.Get<TestMessage>("1");
            Assert.AreEqual(testMessage, result2);
            Assert.IsInstanceOfType(result2, typeof(TestMessage));
            Assert.AreEqual(result, result2);
            Assert.IsTrue(result == result2);

            result = null;

            Assert.AreEqual(testMessage, result2);
        }
    }

    internal class TestMessage
    {
    }

    internal class TestMessage2
    {
    }
}
