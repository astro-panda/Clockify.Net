using System.Threading;
using System.Threading.Tasks;

namespace Clockify.Net.Execution;

public interface IRequest<TResponse> where TResponse : class
{
    public Task<Result<TResponse>> SendAsync(CancellationToken cancellationToken = default);
}
