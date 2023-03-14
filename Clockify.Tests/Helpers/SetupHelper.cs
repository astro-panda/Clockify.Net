using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clockify.Net;
using Clockify.Net.Models;
using Clockify.Net.Models.Enums;
using Clockify.Net.Models.Policies;
using Clockify.Net.Models.TimeEntries;
using Clockify.Net.Models.Workspaces;
using FluentAssertions;

namespace Clockify.Tests.Helpers;

public class SetupHelper {
	/// <summary>
	/// Creates or finds workspace and return workspace id
	/// </summary>
	public static async Task<string> CreateOrFindWorkspaceAsync(ClockifyClient client, string workspaceName) {
		var workspaceResponse = await client.CreateWorkspaceAsync(new WorkspaceRequest { Name = workspaceName });
		string workspaceId;
		// workspaceResponse.IsSuccessful.Should().BeTrue();

		if (workspaceResponse.IsSuccessful) {
			workspaceId = workspaceResponse.Data.Id;
		}
		else if (WorkspaceAlreadyExist(workspaceResponse)) {
			var workspacesResponse = await client.GetWorkspacesAsync();
			var workspace = workspacesResponse.Data.SingleOrDefault(dto => dto.Name == workspaceName);
			if (workspace == null)
				throw new NullReferenceException($"Workspace {workspaceName} do not exist.");
			return workspace.Id;
		}
		else {
			throw new InvalidOperationException($"Cannot create or find workspace: {workspaceResponse.Content}");
		}

		return workspaceId;
	}

	public static async Task<TimeEntryDtoImpl> CreateTestTimeEntryAsync(ClockifyClient client, string workspaceId, DateTimeOffset start, string projectId) {
		var timeEntryRequest = new TimeEntryRequest {
			Start = start,
			End = start.AddSeconds(30),
			ProjectId = projectId
		};

		var createResult = await client.CreateTimeEntryAsync(workspaceId, timeEntryRequest);
		createResult.IsSuccessful.Should().BeTrue();
		return createResult.Data;
	}
		
	public async Task<string> CreateOrFindWorkspaceAsync(string workspaceName) {
		return await CreateOrFindWorkspaceAsync(new ClockifyClient(), workspaceName);
	}


	private static bool WorkspaceAlreadyExist(Response<WorkspaceDto> workspaceResponse) {
		return workspaceResponse.StatusCode == HttpStatusCode.BadRequest &&
		       workspaceResponse.Content.Contains("already exist");
	}

	/// <summary>
	/// Finds first user in workspace and returns user id
	/// </summary>
	public static async Task<string> FindFirstUserIdInWorkspaceAsync(ClockifyClient client, string workspaceId) {
		var allUsersOnWorkspace = await client.FindAllUsersOnWorkspaceAsync(workspaceId);
		var firstUser = allUsersOnWorkspace.Data.First();
		if (firstUser == null)
			throw new NullReferenceException($"Couldn't find user in workspace with id {workspaceId}.");
		return firstUser.ID;
	}

	public static async Task<string> CreateOrFindPolicy(ClockifyClient client, string workspaceId, string userId, string policyName)
	{
		var policyResponse = await client.CreateTimeOffPolicyAsync(workspaceId, new PolicyRequest
		{
			Name = policyName,
			AllowNegativeBalance = true,
			Approve = new PolicyApprove(),
			TimeUnit = TimeUnitEnum.DAYS,
			Users = new ContainsFilter
			{
				Ids = new []{ userId }
			}
		});
		
		string policyId;
		if (policyResponse.IsSuccessful) {
			policyId = policyResponse.Data.Id;
		}
		else if (PolicyAlreadyExist(policyResponse)) {
			var policiesResponse = await client.GetPoliciesAsync(workspaceId);
			var policy = policiesResponse.Data.SingleOrDefault(dto => dto.Name == policyName);
			if (policy == null)
				throw new NullReferenceException($"Policy {policyName} do not exist.");
			return policy.Id;
		}
		else {
			throw new InvalidOperationException($"Cannot create or find policy: {policyResponse.Content}");
		}

		return policyId;
	}
	
	private static bool PolicyAlreadyExist(Response<PolicyDto> policyResponse) {
		return policyResponse.StatusCode == HttpStatusCode.BadRequest &&
		       policyResponse.Content.Contains("already exist");
	}
}