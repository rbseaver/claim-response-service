using ClaimParser.Lib;
using Fluency.DataGeneration;
using Moq;
using NUnit.Framework;

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

        [Test]
        public void ItShouldCallClaimParserServiceMethodWhenAcceptingClaimText()
        {
            var claimText = ARandom.String(100);
            var claimParserMock = new Mock<IClaimParserService>();
            claimParserMock.Setup(x => x.ParseClaims(claimText));

            var service = new ClaimResponseService(claimParserMock.Object);

            service.GenerateClaimResponse(claimText);

            claimParserMock.Verify(x => x.ParseClaims(It.Is<string>(s => s == claimText)), Times.Once);
        }

        [Test]
        public void ItShouldGenerateJsonResponse()
        {
            var claimText = @"1. A product tag system, comprising:
an RFID tag adapted for attachment to a product;
at least one data store in said tag for bar code information relating to said product;
a tag detacher for removing said tag from said product at a point of sale;
an RFID tag reader for retrieving said bar code information from said tag when said tag is placed in said tag detacher; and,
a display for presenting said bar code information in a form which can be scanned by a conventional bar code scanner, said display associated with said tag detacher and said RFID tag reader at said point of sale.
2. The system of claim 1, wherein said tag further comprises a detectable EAS element.
3. The system of claim 1, wherein said tag detacher is inoperable for detaching said tag until said bar code information has been read.
4. The system of claim 1, wherein said tag further comprises a further data store for further product information.
5. The system of claim 1, further including a display for displaying human readable information related to said product.
6. The system of claim 1, wherein said tag detacher is inoperable for detaching said tag until said tag detacher receives a confirmation signal that said bar code information has been successfully read by said bar code scanner.
7. The system of claim 1, wherein said tag detacher comprises means for receiving a confirmation signal that said bar code information has been successfully read by said bar code scanner, said tag being detached responsive to said confirmation signal.
8. The system of claim 1, wherein said tag detacher and said RFID tag reader are integrated in a single housing.
9. The system of claim 1, wherein said tag detacher and said display are integrated in a single housing.
10. The system of claim 9, wherein said single housing is adapted for mounting in a fixed position with respect to said conventional bar code scanner.
11. The system of claim 1, wherein said display and said RFID tag reader are integrated in a single housing.
12. The system of claim 11, wherein said single housing is adapted for mounting in a fixed position with respect to said conventional bar code scanner.
13. The system of claim 11, wherein said single housing is adapted for mounting in a fixed position with respect to said conventional bar code scanner.
14. The system of claim 11, wherein said tag detacher, said RFID tag reader and said display are integrated in a single housing.
15. The system of claim 1, wherein said display is adapted for mounting in a fixed position with respect to said conventional bar code scanner.
16. The system of claim 1, further comprising an RFID writer.
17. The system of claim 16, wherein said tag comprises a further data store for receiving from said RFID writer information regarding said sale of said product, whereby said product sale information is available for subsequent use.
18. A product tag system, comprising:
an RFID tag adapted for attachment to a product;
at least one data store in said tag for bar code information relating to said product;
a tag detacher for removing said tag from said product at a point of sale;
an RFID tag reader for retrieving said bar code information from said tag when said tag is placed in said tag detacher;
a display for presenting said bat code information in a form which can be scanned by a conventional bar code scanner;
a hand-held RFID reader adapted for attachment to a hand-held bar code scanner;
a display on said hand-held RFID reader, said display being in an aligned position when said reader and said scanner are attached for presenting said bar code information in a form which can be scanned by said hand-held bar code scanner; and,
a tag detacher remote from said reader for detaching said tag after said displayed bar code is scanned.
19. The system of claim 18, wherein said tag detacher automatically detaches said tag responsive to a signal transmitted by said reader.
20. A method for monitoring products, comprising the steps of:
attaching an RFID tag to a product;
writing bar code information onto said tag;
retrieving said bar code information from said tag at a point of sale; and,
displaying, at said point of sale, said bar code information in a form which can be scanned by a conventional bar code scanner at said point of sale.
21. The method of claim 20, further comprising the step of activating a detectable EAS element in said tag prior to said retrieving step.
22. The method of claim 21, wherein said attaching, writing and activating steps can occur in any order.
23. The method of claim 20, further comprising the step of detaching said tag from said product.
24. The method of claim 23, comprising the step of performing said retrieving, displaying and detaching steps with components disposed in a single housing.
25. The method of claim 24, comprising the step of disposing said housing in a fixed position relative to said conventional bar code scanner.
26. The method of claim 20, wherein said attaching and writing steps can occur in any order.
27. The method of claim 20, further comprising the step of displaying said bar code information from a position fixed relative to said conventional bar code scanner.
28. The method of claim 20, further comprising displaying said bar code information in human readable form.
29. The method of claim 20, further comprising the step of writing to said tag, at said point of sale, information regarding said sale of said product, whereby said product sale information is available for subsequent use.";

            var service = new ClaimResponseService(new ClaimParserService());

            var response = service.GenerateClaimResponse(claimText);

            Assert.That(response, Is.EqualTo(@"{""claims"":[{""sequence"":1,""claimText"":""A product tag system, comprising:\nan RFID tag adapted for attachment to a product;\r\nat least one data store in said tag for bar code information relating to said product;\r\na tag detacher for removing said tag from said product at a point of sale;\r\nan RFID tag reader for retrieving said bar code information from said tag when said tag is placed in said tag detacher; and,\r\na display for presenting said bar code information in a form which can be scanned by a conventional bar code scanner, said display associated with said tag detacher and said RFID tag reader at said point of sale.""},{""sequence"":2,""claimText"":""The system of claim 1, wherein said tag further comprises a detectable EAS element.""},{""sequence"":3,""claimText"":""The system of claim 1, wherein said tag detacher is inoperable for detaching said tag until said bar code information has been read.""},{""sequence"":4,""claimText"":""The system of claim 1, wherein said tag further comprises a further data store for further product information.""},{""sequence"":5,""claimText"":""The system of claim 1, further including a display for displaying human readable information related to said product.""},{""sequence"":6,""claimText"":""The system of claim 1, wherein said tag detacher is inoperable for detaching said tag until said tag detacher receives a confirmation signal that said bar code information has been successfully read by said bar code scanner.""},{""sequence"":7,""claimText"":""The system of claim 1, wherein said tag detacher comprises means for receiving a confirmation signal that said bar code information has been successfully read by said bar code scanner, said tag being detached responsive to said confirmation signal.""},{""sequence"":8,""claimText"":""The system of claim 1, wherein said tag detacher and said RFID tag reader are integrated in a single housing.""},{""sequence"":9,""claimText"":""The system of claim 1, wherein said tag detacher and said display are integrated in a single housing.""},{""sequence"":10,""claimText"":""The system of claim 9, wherein said single housing is adapted for mounting in a fixed position with respect to said conventional bar code scanner.""},{""sequence"":11,""claimText"":""The system of claim 1, wherein said display and said RFID tag reader are integrated in a single housing.""},{""sequence"":12,""claimText"":""The system of claim 11, wherein said single housing is adapted for mounting in a fixed position with respect to said conventional bar code scanner.""},{""sequence"":13,""claimText"":""The system of claim 11, wherein said single housing is adapted for mounting in a fixed position with respect to said conventional bar code scanner.""},{""sequence"":14,""claimText"":""The system of claim 11, wherein said tag detacher, said RFID tag reader and said display are integrated in a single housing.""},{""sequence"":15,""claimText"":""The system of claim 1, wherein said display is adapted for mounting in a fixed position with respect to said conventional bar code scanner.""},{""sequence"":16,""claimText"":""The system of claim 1, further comprising an RFID writer.""},{""sequence"":17,""claimText"":""The system of claim 16, wherein said tag comprises a further data store for receiving from said RFID writer information regarding said sale of said product, whereby said product sale information is available for subsequent use.""},{""sequence"":18,""claimText"":""A product tag system, comprising:\nan RFID tag adapted for attachment to a product;\r\nat least one data store in said tag for bar code information relating to said product;\r\na tag detacher for removing said tag from said product at a point of sale;\r\nan RFID tag reader for retrieving said bar code information from said tag when said tag is placed in said tag detacher;\r\na display for presenting said bat code information in a form which can be scanned by a conventional bar code scanner;\r\na hand-held RFID reader adapted for attachment to a hand-held bar code scanner;\r\na display on said hand-held RFID reader, said display being in an aligned position when said reader and said scanner are attached for presenting said bar code information in a form which can be scanned by said hand-held bar code scanner; and,\r\na tag detacher remote from said reader for detaching said tag after said displayed bar code is scanned.""},{""sequence"":19,""claimText"":""The system of claim 18, wherein said tag detacher automatically detaches said tag responsive to a signal transmitted by said reader.""},{""sequence"":20,""claimText"":""A method for monitoring products, comprising the steps of:\nattaching an RFID tag to a product;\r\nwriting bar code information onto said tag;\r\nretrieving said bar code information from said tag at a point of sale; and,\r\ndisplaying, at said point of sale, said bar code information in a form which can be scanned by a conventional bar code scanner at said point of sale.""},{""sequence"":21,""claimText"":""The method of claim 20, further comprising the step of activating a detectable EAS element in said tag prior to said retrieving step.""},{""sequence"":22,""claimText"":""The method of claim 21, wherein said attaching, writing and activating steps can occur in any order.""},{""sequence"":23,""claimText"":""The method of claim 20, further comprising the step of detaching said tag from said product.""},{""sequence"":24,""claimText"":""The method of claim 23, comprising the step of performing said retrieving, displaying and detaching steps with components disposed in a single housing.""},{""sequence"":25,""claimText"":""The method of claim 24, comprising the step of disposing said housing in a fixed position relative to said conventional bar code scanner.""},{""sequence"":26,""claimText"":""The method of claim 20, wherein said attaching and writing steps can occur in any order.""},{""sequence"":27,""claimText"":""The method of claim 20, further comprising the step of displaying said bar code information from a position fixed relative to said conventional bar code scanner.""},{""sequence"":28,""claimText"":""The method of claim 20, further comprising displaying said bar code information in human readable form.""},{""sequence"":29,""claimText"":""The method of claim 20, further comprising the step of writing to said tag, at said point of sale, information regarding said sale of said product, whereby said product sale information is available for subsequent use.""}]}"));
        }
    }
}