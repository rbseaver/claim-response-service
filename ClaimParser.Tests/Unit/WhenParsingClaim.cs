using ClaimParser.Lib;
using ClaimParser.Lib.Domain;
using Fluency.DataGeneration;
using NUnit.Framework;
using System;

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
        public void ItShouldThrowArgumentExceptionOnEmptyClaimText()
        {
            var service = new ClaimParserService();
            Assert.Throws<ArgumentException>(() => service.ParseClaims(string.Empty));
        }

        [Test]
        public void AndParsingClaimItShouldConvertToDomainObject()
        {
            var service = new ClaimParserService();
            var patentClaim = service.ParseClaims(ARandom.String(100));

            Assert.That(patentClaim, Is.Not.Null);
        }
    }
}