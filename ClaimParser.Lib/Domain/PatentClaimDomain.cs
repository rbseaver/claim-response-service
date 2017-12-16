using System.Collections.Generic;

namespace ClaimParser.Lib.Domain
{
    public class PatentClaimDomain
    {
        public IEnumerable<PatentClaim> PatentClaims { get; set; }
    }

    public class PatentClaim
    {
        public int Sequence { get; set; }
        public string ClaimText { get; set; }
    }
}