using ClaimParser.Lib;
using NUnit.Framework;

namespace ClaimParser.Tests.Unit
{
    [TestFixture]
    public class WhenParsingClaim
    {
        [Test]
        public void AndInitializingServiceItShouldNotBlowUp()
        {
            Assert.DoesNotThrow(() => new ClaimParserService());
        }
    }
}