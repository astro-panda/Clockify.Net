using System.Threading;
using System.Threading.Tasks;

using Clockify.Net.Models.Users;

namespace Clockify.Net.Execution.Members.CurrentUser;

public class MemberCurrentUserRequest : IRequest<Models.Users.MemberCurrentUserResponse>
{
    public bool IncludeMemberships { get; set; } = false;

    public Task<Result<MemberCurrentUserResponse>> SendAsync(CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}