using Newtonsoft.Json;
using System;

namespace ClaimParser.Lib
{
    public class ClaimResponseService
    {
        private IClaimParserService _claimParserService;

        public ClaimResponseService(IClaimParserService claimParserService)
        {
            _claimParserService = claimParserService;
        }

        public string GenerateClaimResponse(string claimText)
        {
            var claimModel = _claimParserService.ParseClaims(claimText);

            var response = JsonConvert.SerializeObject(claimModel);

            return response;
        }
    }
}