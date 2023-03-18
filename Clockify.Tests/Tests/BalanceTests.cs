using System;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models.Balance;
using Clockify.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Clockify.Tests.Tests;

/// <summary>
///   These tests require a Workspace with at least a standard subscription to pass!
/// </summary>
[Ignore("Need a Clockify Premium plan")]
public class BalanceTests
{
    private readonly ClockifyClient _client;
    private string _workspaceId;
    private string _firstUserId;
    private string _policyId;

    public BalanceTests()
    {
        _client = new ClockifyClient();
    }

    [OneTimeSetUp]
    public async Task Setup()
    {
        _workspaceId = await SetupHelper.CreateOrFindWorkspaceAsync(_client, "Clockify.NetTestWorkspace");
        _firstUserId = await SetupHelper.FindFirstUserIdInWorkspaceAsync(_client, _workspaceId);
        _policyId = await SetupHelper.CreateOrFindPolicy(_client, _workspaceId, _firstUserId, "Test policy " + Guid.NewGuid());
    }
    
    [OneTimeTearDown]
    public async Task TearDown()
    {
        await _client.ArchiveAndDeletePolicyAsync(_workspaceId, _policyId);
    }

    [Test]
    public async Task GetBalanceByPolicyAsync_GetsBalanceForUserAndReturnsDto()
    {
        // assign & act
        var result = await _client.GetBalanceByPolicyAsync(_workspaceId, _policyId);
        
        // assert
        result.IsSuccessful.Should().BeTrue();
        result.Data.Should().NotBeNull();
    }

    [Test]
    public async Task UpdateBalanceAsync_UpdatesBalanceOnPolicy()
    {
        // assign
        var updateBalanceRequest = new UpdateBalanceRequest(new[]{_firstUserId}, 1);
        
        // act
        var response = await _client.UpdateBalanceAsync(_workspaceId, _policyId, updateBalanceRequest);
        
        // assert
        response.IsSuccessful.Should().BeTrue();
        response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        
        // cleanup
        updateBalanceRequest.Value = -1;
        await _client.UpdateBalanceAsync(_workspaceId, _policyId, updateBalanceRequest);
    }

    [Test]
    public async Task GetBalanceByUserAsync_GetsBalancesForUserAndReturnsDto()
    {
        // assign & act
        var result = await _client.GetBalanceByUserAsync(_workspaceId, _firstUserId);
        
        // assert
        result.IsSuccessful.Should().BeTrue();
        result.Data.Should().NotBeNull();
    }
}