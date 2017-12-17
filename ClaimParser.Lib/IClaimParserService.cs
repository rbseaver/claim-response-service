using ClaimParser.Lib.Domain;

namespace ClaimParser.Lib
{
    public interface IClaimParserService
    {
        PatentClaimCollection ParseClaims(string claimText);
    }
}