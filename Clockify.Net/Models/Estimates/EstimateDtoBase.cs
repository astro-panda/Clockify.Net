namespace Clockify.Net.Models.Estimates
{
    public class EstimateDtoBase
    {
        public EstimateType Type { get; set; }
        public bool Active { get; set; }
        public ResetOptionType? ResetOption { get; set; }
    }
}