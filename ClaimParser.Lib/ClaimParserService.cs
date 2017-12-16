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
            CheckForEmpty(claimText);

            var model = new PatentClaimDomain
            {
                PatentClaims = new List<PatentClaim>()
            };

            var claims = ConvertToArray(claimText);

            AddClaimsToModel(model, claims);

            return model;
        }

        private static void AddClaimsToModel(PatentClaimDomain model, IEnumerable<string> claims)
        {
            var sequencer = 1;

            foreach (var claim in claims)
            {
                model.PatentClaims.Add(new PatentClaim
                {
                    Sequence = sequencer,
                    ClaimText = claim.Trim()
                });
                sequencer++;
            }
        }

        private static void CheckForEmpty(string claimText)
        {
            if (string.IsNullOrEmpty(claimText))
            {
                throw new ArgumentException("Text cannot be null or empty");
            }
        }

        private static IEnumerable<string> ConvertToArray(string claimText)
        {
            const string splitPattern = @"\n?\d{1,}\.\s";
            var claims = Regex.Split(claimText, splitPattern)
                                .Where(c => c != string.Empty).ToArray(); // No empty lines.
            return claims;
        }
    }
}