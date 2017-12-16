using ClaimParser.Lib.Domain;

namespace ClaimParser.Lib
{
    public interface IClaimParserService
    {
        PatentClaimDomain ParseClaims(string claimText);
    }
}