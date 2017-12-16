using ClaimParser.Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimParser.Tests.Unit
{
    [TestFixture]
    public class WhenGeneratingResponse
    {
        [Test]
        public void ItShouldInitializeServiceWithoutError()
        {
            Assert.DoesNotThrow(() => new ClaimResponseService(new ClaimParserService()));
        }
    }
}