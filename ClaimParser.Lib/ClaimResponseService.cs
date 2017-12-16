namespace ClaimParser.Lib
{
    public class ClaimResponseService
    {
        private ClaimParserService _claimParserService;

        public ClaimResponseService(ClaimParserService claimParserService)
        {
            _claimParserService = claimParserService;
        }
    }
}