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
            if (string.IsNullOrEmpty(claimText))
            {
                throw new ArgumentException("Text cannot be null or empty");
            }

            return new PatentClaimDomain();
        }
    }
}