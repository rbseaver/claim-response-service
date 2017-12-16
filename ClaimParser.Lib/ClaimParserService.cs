using ClaimParser.Lib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            var model = new PatentClaimDomain
            {
                PatentClaims = new List<PatentClaim>()
            };

            const string splitPattern = @"\n?\d{1,}\.\s";
            var claims = Regex.Split(claimText, splitPattern)
                                .Where(c => c != string.Empty); // No empty lines.

            var sequencer = 1;

            foreach (var claim in claims)
            {
                model.PatentClaims.Add(new PatentClaim
                {
                    Sequence = sequencer,
                    ClaimText = claim
                });
                sequencer++;
            }

            return model;
        }
    }
}