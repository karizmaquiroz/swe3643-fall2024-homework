using NUnit.Framework;
using Homework1;


namespace Tests
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassingTest()
        {
            Assert.AreEqual(4, Calculator.Add(2, 2));
        }

        [Test]
        public void FailingTest()
        {
            Assert.AreEqual(4, Calculator.Add(2, 2));
        }
    }
}