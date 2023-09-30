using System;

namespace Clockify.Net.Exceptions;

public class InvalidClockifyConfigurationException : Exception
{
    public InvalidClockifyConfigurationException(string message) : base(message)
    {
    }
}
