using ClaimParser.Lib;
using ClaimParser.Lib.Domain;
using Fluency.DataGeneration;
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

        [Test]
        public void AndParsingTextItShouldAcceptString()
        {
            var service = new ClaimParserService();
            Assert.DoesNotThrow(() => service.ParseClaims(ARandom.String(100)));
        }

        [Test]
        public void AndParsingClaimItShouldConverToDomainObject()
        {
            var service = new ClaimParserService();
            PatentClaimDomain patentClaim = service.ParseClaims(ARandom.String(100));

            Assert.That(patentClaim, Is.Not.Null);
        }
    }
}