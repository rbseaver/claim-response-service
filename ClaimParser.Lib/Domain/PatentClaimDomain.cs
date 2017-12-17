using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClaimParser.Lib.Domain
{
    public class PatentClaimDomain
    {
        [JsonProperty("claims")]
        public IList<PatentClaim> PatentClaims { get; set; }
    }

    public class PatentClaim
    {
        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("claimText")]
        public string ClaimText { get; set; }
    }
}