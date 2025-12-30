
using Clockify.Net.Execution.Members.AddPhoto;
using Clockify.Net.Execution.Members.CurrentUser;

namespace Clockify.Net;

public class MemberRequestBuilder
{
    public MemberAddPhotoRequestBuilder AddPhoto { get; set; }

    public MemberCurrentUserRequestBuilder CurrentUser { get; set; }
  
}