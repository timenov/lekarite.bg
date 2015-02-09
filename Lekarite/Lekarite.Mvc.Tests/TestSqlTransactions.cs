namespace Lekarite.Mvc.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Lekarite.Data;
    using Lekarite.Data.Interfaces;

    [TestClass]
    public class TestSQLTransactions
    {
        [TestMethod]
        public void TestTransaction()
        {
            var data = new LekariteData();

            var names = data.Doctors
                        .All()
                        .Select(d => d.FirstName)
                        .Distinct();

            Assert.AreEqual(345, names.Count());
        }
    }
}
