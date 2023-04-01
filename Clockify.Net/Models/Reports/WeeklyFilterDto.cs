using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports; 

public class WeeklyFilterDto {
	public WeeklyGroupType Group { get; set; }
	public WeeklySubgroupType Subgroup { get; set; }
}

public enum WeeklyGroupType {
	[EnumMember(Value = "PROJECT")]
	PROJECT,
	[EnumMember(Value = "USER")]
	USER
}
	
public enum WeeklySubgroupType {
	[EnumMember(Value = "TIME")]
	TIME,
	[EnumMember(Value = "EARNED")]
	EARNED
}