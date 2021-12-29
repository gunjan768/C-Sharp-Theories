using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mosh_Hamedani.Tests
{
    // [ClassName]: This is an attribute. Attribute represents meta data about the classes and their members. They don't have any logic, they
    // are just marker.

    // To rename, press (ctrl + r) twice.
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod1()
        {
            var order = new Order(new FakeShipping());

            // Expected result: InvalidOperationException
            order.Process(0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var order = new Order(new FakeShipping());

            Assert.AreEqual(1, order.Process(1));
        }
    }

    public class FakeShipping : IShipping
    {
        public float Cal(double c)
        {
            return 1.0f;
        }
    }
}
