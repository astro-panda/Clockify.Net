using Clockify.Net.Models.Reports;

namespace Clockify.Net.Api.User.Responses; 

public class UserCustomField
{
    public string CustomFieldId { get; set; }
    public string CustomFieldName { get; set; }
    public string CustomFieldType { get; set; }
    public string UserId { get; set; }
    public object Value { get; set; }
}