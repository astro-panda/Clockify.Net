using System;

using Clockify.Net.Models;

namespace Clockify.Net.Execution;

public class Result<TValue> where TValue : class
{
    public Response Response { get; set; }

    public TValue Value { get; set; }

    public bool IsSuccess => Response?.IsSuccessful == true;

    public bool IsFailure => !IsSuccess;

    public Exception? Exception => Response?.ErrorException;    
}
