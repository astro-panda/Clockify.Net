namespace Clockify.Net.Execution.Members.CurrentUser;

public class MemberCurrentUserRequestBuilder : IExecutingRequestBuilder<MemberCurrentUserRequest>
{
    private MemberCurrentUserRequest _request;

    public MemberCurrentUserRequestBuilder IncludeMemberships(bool includeMemberships = true)
    {
        _request.IncludeMemberships = includeMemberships;
        return this;
    }

    public MemberCurrentUserRequest Request => _request;
}