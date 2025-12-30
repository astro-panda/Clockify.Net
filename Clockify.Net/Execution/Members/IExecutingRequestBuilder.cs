namespace Clockify.Net.Execution.Members;

public interface IExecutingRequestBuilder<IRequest>
{
    public IRequest Request { get; }
}
