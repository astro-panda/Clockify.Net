using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Holiday;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

// TODO: Implement test cases
public class BalanceTests
{
    private readonly ClockifyClient _client;
    private string _workspaceId;

    public BalanceTests()
    {
        _client = new ClockifyClient();
    }

    [OneTimeSetUp]
    public async Task Setup()
    {
        _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
    }
}