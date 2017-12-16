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
            var service = MakeService();
            Assert.DoesNotThrow(() => service.ParseClaims(ARandom.String(100)));
        }

        [Test]
        public void ItShouldThrowArgumentExceptionOnEmptyClaimText()
        {
            var service = MakeService(); ;
            Assert.Throws<ArgumentException>(() => service.ParseClaims(string.Empty));
        }

        [Test]
        public void AndParsingClaimItShouldConvertToDomainObject()
        {
            var service = MakeService();
            var patentClaim = service.ParseClaims(ARandom.String(100));

            Assert.That(patentClaim, Is.Not.Null);
        }

        [Test]
        public void ItShouldPopulateObject()
        {
            var claimText = @"1. A product tag system, comprising:
an RFID tag adapted for attachment to a product;
at least one data store in said tag for bar code information relating to said product;
a tag detacher for removing said tag from said product at a point of sale;
an RFID tag reader for retrieving said bar code information from said tag when said tag is placed in said tag detacher; and,
a display for presenting said bar code information in a form which can be scanned by a conventional bar code scanner, said display associated with said tag detacher and said RFID tag reader at said point of sale.
2. The system of claim 1, wherein said tag further comprises a detectable EAS element.
3. The system of claim 1, wherein said tag detacher is inoperable for detaching said tag until said bar code information has been read.
4. The system of claim 1, wherein said tag further comprises a further data store for further product information.";
            var service = MakeService();
            var patentClaim = service.ParseClaims(claimText);

            Assert.That(patentClaim.PatentClaims.Count, Is.EqualTo(4));

            Assert.That(patentClaim.PatentClaims[0].Sequence, Is.EqualTo(1));
            Assert.That(patentClaim.PatentClaims[1].Sequence, Is.EqualTo(2));
            Assert.That(patentClaim.PatentClaims[2].Sequence, Is.EqualTo(3));
            Assert.That(patentClaim.PatentClaims[3].Sequence, Is.EqualTo(4));

            Assert.That(patentClaim.PatentClaims[0].ClaimText, Is.EqualTo(@"A product tag system, comprising:
an RFID tag adapted for attachment to a product;
at least one data store in said tag for bar code information relating to said product;
a tag detacher for removing said tag from said product at a point of sale;
an RFID tag reader for retrieving said bar code information from said tag when said tag is placed in said tag detacher; and,
a display for presenting said bar code information in a form which can be scanned by a conventional bar code scanner, said display associated with said tag detacher and said RFID tag reader at said point of sale."));
            Assert.That(patentClaim.PatentClaims[1].ClaimText, Is.EqualTo(@"The system of claim 1, wherein said tag further comprises a detectable EAS element."));
            Assert.That(patentClaim.PatentClaims[2].ClaimText, Is.EqualTo(@"The system of claim 1, wherein said tag detacher is inoperable for detaching said tag until said bar code information has been read."));
            Assert.That(patentClaim.PatentClaims[3].ClaimText, Is.EqualTo(@"The system of claim 1, wherein said tag further comprises a further data store for further product information."));
        }

        private static ClaimParserService MakeService()
        {
            return new ClaimParserService();
        }
    }
}