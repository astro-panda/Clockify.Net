using System.Threading.Tasks;
using Clockify.Net.Api.Balance.Requests;
using Clockify.Net.Api.Balance.Responses;
using Clockify.Net.Models;

namespace Clockify.Net.Api.Balance; 

public interface IClockifyBalanceApi {
	/// <summary>
	/// Get Balance by Policy Id.
	/// </summary>
	/// <returns></returns>
	Task<Response<GetBalanceResponse>> GetBalanceByPolicyAsync(string workspaceId, string policyId, GetBalanceRequest? getBalanceRequest = null);
	/// <summary>
	/// Get Balance by User Id.
	/// </summary>
	/// <returns></returns>
	Task<Response<GetBalanceResponse>> GetBalanceByUserAsync(string workspaceId, string userId, GetBalanceRequest? balance = null);
	/// <summary>
	/// Update Balance on workspace.
	/// </summary>
	Task<Response> UpdateBalanceAsync(string workspaceId, string policyId, UpdateBalanceRequest balance);
}