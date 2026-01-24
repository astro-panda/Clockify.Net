
using Clockify.Net;

namespace Clockify.Net;

public class ClockifyService(IMemberService members) : IClockifyService
{
    public IMemberService Members => members;

    public IMemberService Users => members;
}