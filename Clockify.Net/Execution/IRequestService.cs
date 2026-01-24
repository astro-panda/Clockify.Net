using System.Threading;
using System.Threading.Tasks;

namespace Clockify.Net.Execution;

public interface IRequestService<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : class
{
    public TRequest Request { get; }

    public Task<Result<TResponse>> SendAsync(CancellationToken cancellationToken = default);
}
