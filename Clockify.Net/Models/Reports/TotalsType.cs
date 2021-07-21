using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum TotalsType
    {
        [EnumMember(Value = "CALCULATE")]
        CALCULATE,
        [EnumMember(Value = "EXCLUDE")]
        EXCLUDE
    }
}