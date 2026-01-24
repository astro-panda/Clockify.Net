

namespace Clockify.Net;

public interface IClockifyService
{
    public IMemberService Members { get; }

    public IMemberService Users { get; }
}