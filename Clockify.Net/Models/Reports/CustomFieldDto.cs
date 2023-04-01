namespace Clockify.Net.Models.Reports; 

public class CustomFieldDto
{
    public string Id { get; set; }
    public string Value { get; set; }
    public CustomFieldType Type { get; set; }
    public NumberConditionType NumberCondition {get; set;}
    public bool? Empty { get; set; }
}