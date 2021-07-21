using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum CustomFieldType
    {
        [EnumMember(Value = "NUMBER")]
        NUMBER,
        [EnumMember(Value = "SUMMARY")]
        SUMMARY
    }
}