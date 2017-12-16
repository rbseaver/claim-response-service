using ClaimParser.Lib.Domain;
using System;

namespace ClaimParser.Lib
{
    public class ClaimParserService
    {
        public ClaimParserService()
        {
        }

        public PatentClaimDomain ParseClaims(string claimText)
        {
            return new PatentClaimDomain();
        }
    }
}