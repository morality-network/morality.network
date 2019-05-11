using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Utilities;

namespace RateIt.TestSuite.IntegrationTests
{
    public class ConfigReaderTests
    {
        [SetUp]
        public void Setup()
        {}

        [Test]
        public void InfuraTest()
        {
            var reader = ConfigReader.GetInstance();
            var value = reader.Infura;
            Assert.IsNotNull(value);
        }
    }
}
