using System;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Holiday;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

// TODO: Implement test cases
/// <summary>
/// These tests require a Workspace with at least a standard subscription to pass!
/// </summary>
public class PolicyTests
{
    private readonly ClockifyClient _client;
    private string _workspaceId;

    public PolicyTests()
    {
        _client = new ClockifyClient();
    }

    [OneTimeSetUp]
    public async Task Setup()
    {
        _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
    }
}