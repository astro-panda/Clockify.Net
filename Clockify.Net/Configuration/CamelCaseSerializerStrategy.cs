using System.Text;
using RestSharp;

namespace Clockify.Net.Configuration
{
    public class CamelCaseSerializerStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            var builder = new StringBuilder(clrPropertyName);
            if (!string.IsNullOrEmpty(clrPropertyName))
            {
                builder[0] = char.ToLowerInvariant(builder[0]);
            }
            return builder.ToString();
        }
    }
}