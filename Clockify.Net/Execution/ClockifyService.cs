
using Clockify.Net;

namespace Clockify.Net;

public class ClockifyService : IClockifyService
{
    public MemberRequestBuilder Members { get; set; } = new MemberRequestBuilder();

    public MemberRequestBuilder Users { get; set; } = new MemberRequestBuilder();
}