using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Clockify.Net.Execution;

public class MemberAddPhotoRequest : IRequest<MemberAddPhotoResponse>
{
    public MemoryStream Photo { get; set; }

    public Task<Result<MemberAddPhotoResponse>> SendAsync(CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}
