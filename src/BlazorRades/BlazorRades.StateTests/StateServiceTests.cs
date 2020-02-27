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
        public void AddOrReplaceTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage { TestProperty = 1 };
            sut.AddOrReplace<TestMessage>("1", testMessage);
            var result = sut.Get<TestMessage>("1");
            Assert.AreEqual(testMessage, result);
            Assert.IsInstanceOfType(result, typeof(TestMessage));

            var testMessage2 = new TestMessage { TestProperty = 2 };
            sut.AddOrReplace<TestMessage>("1", testMessage2);
            result = sut.Get<TestMessage>("1");
            Assert.AreEqual(testMessage2, result);
            Assert.IsInstanceOfType(result, typeof(TestMessage));
        }

        [TestMethod]
        public void GetTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage { TestProperty = 1 };
            sut.AddOrReplace<TestMessage>("1", testMessage);
            var result = sut.Get<TestMessage>("2");
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetCountTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage();
            sut.Add<TestMessage>("1", testMessage);
            var testMessage2 = new TestMessage();
            sut.Add<TestMessage>("1", testMessage2);
            var testMessage3 = new TestMessage2();
            sut.Add<TestMessage2>("3", testMessage3);
            var result = sut.GetCount<TestMessage>("1");
            Assert.AreEqual(2, result);
            result = sut.GetCount<TestMessage2>("3");
            Assert.AreEqual(1, result);
            result = sut.GetCount<TestMessage2>("2");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddOrUpdateMultipleTypesTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage();
            sut.AddOrReplace<TestMessage>("1", testMessage);
            var testMessage2 = new TestMessage2();
            sut.AddOrReplace<TestMessage2>("2", testMessage2);
            var testMessage3 = new TestMessage2();
            sut.AddOrReplace<TestMessage2>("3", testMessage3);

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

        [TestMethod]
        public void AddMultipleTypesTest()
        {
            var sut = new StateService();
            var testMessage = new TestMessage();
            sut.Add<TestMessage>("1", testMessage);
            var testMessage2 = new TestMessage();
            sut.Add<TestMessage>("1", testMessage2);
            var testMessage3 = new TestMessage2();
            sut.Add<TestMessage2>("3", testMessage3);

            var result = sut.GetAll<TestMessage>("1");
            Assert.AreEqual(testMessage, result[0]);
            Assert.IsInstanceOfType(result, typeof(List<TestMessage>));

            var result2 = sut.GetAll<TestMessage>("1");
            Assert.AreEqual(testMessage, result2[0]);
            Assert.IsInstanceOfType(result2, typeof(List<TestMessage>));
            Assert.AreEqual(result, result2);
            Assert.IsTrue(result == result2);

            result = null;

            Assert.AreEqual(testMessage, result2[0]);
        }


    }

    internal class TestMessage
    {
        public int TestProperty { get; set; }
    }

    internal class TestMessage2
    {
        public int TestProperty { get; set; }
    }
}