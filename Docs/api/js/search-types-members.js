
// Variables
const SearchHelper = (function() {
	// Variables
	/** @type {{
			[key : string] : {
				link : string;
				tags : string[];
				types : {
					[key : string] : {
						link : string;
						tags : string[];
						members : {
							link : string;
							tags : string[];
							name : string;
						}[];
					}
				}
			}
		}} - The js object used for searching.*/
	let searchJson = {
 "Clockify.Net": {
  "link": "clockify.net.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "ClockifyClient": {
    "link": "clockify.net.clockifyclient.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.clockifyclient.html#ClockifyClient(System.String)",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ClockifyClient(string apiKey)"
     },
     {
      "link": "clockify.net.clockifyclient.html#ClockifyClient",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ClockifyClient()"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateClientAsync(System.String,Clockify.Net.Models.Clients.ClientRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateClientAsync(string workspaceId, ClientRequest clientRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateProjectAsync(System.String,Clockify.Net.Models.Projects.ProjectRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateProjectAsync(string workspaceId, ProjectRequest projectRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateTagAsync(System.String,Clockify.Net.Models.Tags.TagRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateTagAsync(string workspaceId, TagRequest projectRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateTaskAsync(System.String,System.String,Clockify.Net.Models.Tasks.TaskRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateTaskAsync(string workspaceId, string projectId, TaskRequest taskRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateTemplatesAsync(System.String,Clockify.Net.Models.Templates.TemplateRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateTemplatesAsync(string workspaceId, params TemplateRequest[] projectRequests)"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateTimeEntryAsync(System.String,Clockify.Net.Models.TimeEntries.TimeEntryRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateTimeEntryAsync(string workspaceId, TimeEntryRequest timeEntryRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#CreateWorkspaceAsync(Clockify.Net.Models.Workspaces.WorkspaceRequest)",
      "tags": [
       "member",
       "method"
      ],
      "name": "CreateWorkspaceAsync(WorkspaceRequest workspaceRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#DeleteProjectAsync(System.String,System.String)",
      "tags": [
       "member",
       "method"
      ],
      "name": "DeleteProjectAsync(string workspaceId, string id)"
     },
     {
      "link": "clockify.net.clockifyclient.html#DeleteTaskAsync(System.String,System.String,System.String)",
      "tags": [
       "member",
       "method"
      ],
      "name": "DeleteTaskAsync(string workspaceId, string projectId, string taskId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#DeleteTemplateAsync(System.String,System.String)",
      "tags": [
       "member",
       "method"
      ],
      "name": "DeleteTemplateAsync(string workspaceId, string templateId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#DeleteTimeEntryAsync(System.String,System.String)",
      "tags": [
       "member",
       "method"
      ],
      "name": "DeleteTimeEntryAsync(string workspaceId, string timeEntryId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#DeleteWorkspaceAsync(System.String)",
      "tags": [
       "member",
       "method"
      ],
      "name": "DeleteWorkspaceAsync(string id)"
     },
     {
      "link": "clockify.net.clockifyclient.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.clockifyclient.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllClientsOnWorkspaceAsync(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllClientsOnWorkspaceAsync(string workspaceId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllHydratedTimeEntriesForUserAsync(System.String,System.String,System.String,System.Nullable-1,System.Nullable-1,System.String,System.String,System.Nullable-1,System.Nullable-1,System.Nullable-1,System.Nullable-1,System.Int32,System.Int32)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllHydratedTimeEntriesForUserAsync(string workspaceId, string userId, string description, Nullable&lt;DateTimeOffset&gt; start, Nullable&lt;DateTimeOffset&gt; end, string project, string task, Nullable&lt;bool&gt; projectRequired, Nullable&lt;bool&gt; taskRequired, Nullable&lt;bool&gt; considerDurationFormat, Nullable&lt;bool&gt; inProgress, int page = 1, int pageSize = 50)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllProjectsOnWorkspaceAsync(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllProjectsOnWorkspaceAsync(string workspaceId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllTagsOnWorkspaceAsync(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllTagsOnWorkspaceAsync(string workspaceId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllTasksAsync(System.String,System.String,System.Nullable-1,System.String,System.Int32,System.Int32)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllTasksAsync(string workspaceId, string projectId, Nullable&lt;bool&gt; isActive, string name, int page = 1, int pageSize = 50)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllTemplatesOnWorkspaceAsync(System.String,System.String,System.Boolean,System.Boolean,System.Int32,System.Int32)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllTemplatesOnWorkspaceAsync(string workspaceId, string name, bool cleansed = False, bool hydrated = False, int page = 1, int pageSize = 1)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllTimeEntriesForUserAsync(System.String,System.String,System.String,System.Nullable-1,System.Nullable-1,System.String,System.String,System.Nullable-1,System.Nullable-1,System.Nullable-1,System.Nullable-1,System.Nullable-1,System.Int32,System.Int32)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllTimeEntriesForUserAsync(string workspaceId, string userId, string description, Nullable&lt;DateTimeOffset&gt; start, Nullable&lt;DateTimeOffset&gt; end, string project, string task, Nullable&lt;bool&gt; projectRequired, Nullable&lt;bool&gt; taskRequired, Nullable&lt;bool&gt; considerDurationFormat, Nullable&lt;bool&gt; hydrated, Nullable&lt;bool&gt; inProgress, int page = 1, int pageSize = 50)"
     },
     {
      "link": "clockify.net.clockifyclient.html#FindAllUsersOnWorkspaceAsync(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "FindAllUsersOnWorkspaceAsync(string workspaceId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#GetCurrentUserAsync",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "GetCurrentUserAsync()"
     },
     {
      "link": "clockify.net.clockifyclient.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.clockifyclient.html#GetTemplateAsync(System.String,System.String,System.Boolean,System.Boolean)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTemplateAsync(string workspaceId, string templateId, bool cleansed = False, bool hydrated = False)"
     },
     {
      "link": "clockify.net.clockifyclient.html#GetTimeEntryAsync(System.String,System.String,System.Boolean,System.Boolean)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTimeEntryAsync(string workspaceId, string timeEntryId, bool considerDurationFormat = False, bool hydrated = False)"
     },
     {
      "link": "clockify.net.clockifyclient.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.clockifyclient.html#GetWorkspacesAsync",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetWorkspacesAsync()"
     },
     {
      "link": "clockify.net.clockifyclient.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.clockifyclient.html#SetActiveWorkspaceFor(System.String,System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "SetActiveWorkspaceFor(string userId, string workspaceId)"
     },
     {
      "link": "clockify.net.clockifyclient.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.clockifyclient.html#UpdateTaskAsync(System.String,System.String,Clockify.Net.Models.Tasks.TaskRequest)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "UpdateTaskAsync(string workspaceId, string projectId, TaskRequest taskRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#UpdateTemplateAsync(System.String,System.String,Clockify.Net.Models.Templates.TemplatePatchRequest)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "UpdateTemplateAsync(string workspaceId, string timeEntryId, TemplatePatchRequest templatePatchRequest)"
     },
     {
      "link": "clockify.net.clockifyclient.html#UpdateTimeEntryAsync(System.String,System.String,Clockify.Net.Models.TimeEntries.UpdateTimeEntryRequest)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "UpdateTimeEntryAsync(string workspaceId, string timeEntryId, UpdateTimeEntryRequest updateTimeEntryRequest)"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Clients": {
  "link": "clockify.net.models.clients.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "ClientDto": {
    "link": "clockify.net.models.clients.clientdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.clients.clientdto.html#ClientDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ClientDto()"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.clients.clientdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "ClientRequest": {
    "link": "clockify.net.models.clients.clientrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.clients.clientrequest.html#ClientRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ClientRequest()"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.clients.clientrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Estimates": {
  "link": "clockify.net.models.estimates.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "EstimateDto": {
    "link": "clockify.net.models.estimates.estimatedto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.estimates.estimatedto.html#EstimateDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "EstimateDto()"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#Estimate",
      "tags": [
       "member",
       "property"
      ],
      "name": "Estimate"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#Type",
      "tags": [
       "member",
       "property"
      ],
      "name": "Type"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.estimates.estimatedto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "EstimateRequest": {
    "link": "clockify.net.models.estimates.estimaterequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#EstimateRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "EstimateRequest()"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#Estimate",
      "tags": [
       "member",
       "property"
      ],
      "name": "Estimate"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#Type",
      "tags": [
       "member",
       "property"
      ],
      "name": "Type"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.estimates.estimaterequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "EstimateType": {
    "link": "clockify.net.models.estimates.estimatetype.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.estimates.estimatetype.html#Auto",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Auto"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#Manual",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Manual"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.estimates.estimatetype.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.HourlyRates": {
  "link": "clockify.net.models.hourlyrates.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "HourlyRateDto": {
    "link": "clockify.net.models.hourlyrates.hourlyratedto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#HourlyRateDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "HourlyRateDto()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#Amount",
      "tags": [
       "member",
       "property"
      ],
      "name": "Amount"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#Currency",
      "tags": [
       "member",
       "property"
      ],
      "name": "Currency"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyratedto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "HourlyRateRequest": {
    "link": "clockify.net.models.hourlyrates.hourlyraterequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#HourlyRateRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "HourlyRateRequest()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#Amount",
      "tags": [
       "member",
       "property"
      ],
      "name": "Amount"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#Currency",
      "tags": [
       "member",
       "property"
      ],
      "name": "Currency"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.hourlyrates.hourlyraterequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Memberships": {
  "link": "clockify.net.models.memberships.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "MembershipDto": {
    "link": "clockify.net.models.memberships.membershipdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.memberships.membershipdto.html#MembershipDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "MembershipDto()"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#HourlyRate",
      "tags": [
       "member",
       "property"
      ],
      "name": "HourlyRate"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#MembershipStatus",
      "tags": [
       "member",
       "property"
      ],
      "name": "MembershipStatus"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#MembershipType",
      "tags": [
       "member",
       "property"
      ],
      "name": "MembershipType"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#TargetId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TargetId"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#UserId",
      "tags": [
       "member",
       "property"
      ],
      "name": "UserId"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.memberships.membershipdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "MembershipRequest": {
    "link": "clockify.net.models.memberships.membershiprequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#MembershipRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "MembershipRequest()"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#HourlyRate",
      "tags": [
       "member",
       "property"
      ],
      "name": "HourlyRate"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#MembershipStatus",
      "tags": [
       "member",
       "property"
      ],
      "name": "MembershipStatus"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#MembershipType",
      "tags": [
       "member",
       "property"
      ],
      "name": "MembershipType"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#TargetId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TargetId"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#UserId",
      "tags": [
       "member",
       "property"
      ],
      "name": "UserId"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.memberships.membershiprequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "MembershipStatus": {
    "link": "clockify.net.models.memberships.membershipstatus.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#Active",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Active"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#Declined",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Declined"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#Inactive",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Inactive"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#Pending",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Pending"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.memberships.membershipstatus.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Projects": {
  "link": "clockify.net.models.projects.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "ProjectDtoImpl": {
    "link": "clockify.net.models.projects.projectdtoimpl.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#ProjectDtoImpl",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ProjectDtoImpl()"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Archived",
      "tags": [
       "member",
       "property"
      ],
      "name": "Archived"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Billable",
      "tags": [
       "member",
       "property"
      ],
      "name": "Billable"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#ClientId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ClientId"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#ClientName",
      "tags": [
       "member",
       "property"
      ],
      "name": "ClientName"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Color",
      "tags": [
       "member",
       "property"
      ],
      "name": "Color"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Duration",
      "tags": [
       "member",
       "property"
      ],
      "name": "Duration"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Estimate",
      "tags": [
       "member",
       "property"
      ],
      "name": "Estimate"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#HourlyRate",
      "tags": [
       "member",
       "property"
      ],
      "name": "HourlyRate"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Memberships",
      "tags": [
       "member",
       "property"
      ],
      "name": "Memberships"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Note",
      "tags": [
       "member",
       "property"
      ],
      "name": "Note"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Public",
      "tags": [
       "member",
       "property"
      ],
      "name": "Public"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.projects.projectdtoimpl.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "ProjectRequest": {
    "link": "clockify.net.models.projects.projectrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.projects.projectrequest.html#ProjectRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ProjectRequest()"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Billable",
      "tags": [
       "member",
       "property"
      ],
      "name": "Billable"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#ClientId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ClientId"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Color",
      "tags": [
       "member",
       "property"
      ],
      "name": "Color"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Estimate",
      "tags": [
       "member",
       "property"
      ],
      "name": "Estimate"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#HourlyRate",
      "tags": [
       "member",
       "property"
      ],
      "name": "HourlyRate"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#IsPublic",
      "tags": [
       "member",
       "property"
      ],
      "name": "IsPublic"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Memberships",
      "tags": [
       "member",
       "property"
      ],
      "name": "Memberships"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Note",
      "tags": [
       "member",
       "property"
      ],
      "name": "Note"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Tasks",
      "tags": [
       "member",
       "property"
      ],
      "name": "Tasks"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.projects.projectrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Tags": {
  "link": "clockify.net.models.tags.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "TagDto": {
    "link": "clockify.net.models.tags.tagdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.tags.tagdto.html#TagDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TagDto()"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.tags.tagdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TagRequest": {
    "link": "clockify.net.models.tags.tagrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.tags.tagrequest.html#TagRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TagRequest()"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.tags.tagrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Tasks": {
  "link": "clockify.net.models.tasks.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "TaskDto": {
    "link": "clockify.net.models.tasks.taskdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.tasks.taskdto.html#TaskDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TaskDto()"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#AssigneeIds",
      "tags": [
       "member",
       "property"
      ],
      "name": "AssigneeIds"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#Estimate",
      "tags": [
       "member",
       "property"
      ],
      "name": "Estimate"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#Status",
      "tags": [
       "member",
       "property"
      ],
      "name": "Status"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.tasks.taskdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TaskRequest": {
    "link": "clockify.net.models.tasks.taskrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.tasks.taskrequest.html#TaskRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TaskRequest()"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#AssigneeIds",
      "tags": [
       "member",
       "property"
      ],
      "name": "AssigneeIds"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#Estimate",
      "tags": [
       "member",
       "property"
      ],
      "name": "Estimate"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#Status",
      "tags": [
       "member",
       "property"
      ],
      "name": "Status"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.tasks.taskrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TaskStatus": {
    "link": "clockify.net.models.tasks.taskstatus.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.tasks.taskstatus.html#Active",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Active"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#Done",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Done"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.tasks.taskstatus.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Templates": {
  "link": "clockify.net.models.templates.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "ProjectsTaskTupleDto": {
    "link": "clockify.net.models.templates.projectstasktupledto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#ProjectsTaskTupleDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ProjectsTaskTupleDto()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#TaskId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TaskId"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktupledto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "ProjectsTaskTupleRequest": {
    "link": "clockify.net.models.templates.projectstasktuplerequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#ProjectsTaskTupleRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "ProjectsTaskTupleRequest()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#TaskId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TaskId"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.templates.projectstasktuplerequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TemplateDto": {
    "link": "clockify.net.models.templates.templatedto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.templates.templatedto.html#TemplateDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TemplateDto()"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#ProjectsAndTasks",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectsAndTasks"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#UserId",
      "tags": [
       "member",
       "property"
      ],
      "name": "UserId"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.templates.templatedto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TemplatePatchRequest": {
    "link": "clockify.net.models.templates.templatepatchrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#TemplatePatchRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TemplatePatchRequest()"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.templates.templatepatchrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TemplateRequest": {
    "link": "clockify.net.models.templates.templaterequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.templates.templaterequest.html#TemplateRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TemplateRequest()"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#ProjectsAndTasks",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectsAndTasks"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.templates.templaterequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.TimeEntries": {
  "link": "clockify.net.models.timeentries.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "HydratedTimeEntryDtoImpl": {
    "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#HydratedTimeEntryDtoImpl",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "HydratedTimeEntryDtoImpl()"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Billable",
      "tags": [
       "member",
       "property"
      ],
      "name": "Billable"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Description",
      "tags": [
       "member",
       "property"
      ],
      "name": "Description"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#HourlyRate",
      "tags": [
       "member",
       "property"
      ],
      "name": "HourlyRate"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#IsLocked",
      "tags": [
       "member",
       "property"
      ],
      "name": "IsLocked"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Project",
      "tags": [
       "member",
       "property"
      ],
      "name": "Project"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Tags",
      "tags": [
       "member",
       "property"
      ],
      "name": "Tags"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Task",
      "tags": [
       "member",
       "property"
      ],
      "name": "Task"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#TimeInterval",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeInterval"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#User",
      "tags": [
       "member",
       "property"
      ],
      "name": "User"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#UserId",
      "tags": [
       "member",
       "property"
      ],
      "name": "UserId"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.timeentries.hydratedtimeentrydtoimpl.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TimeEntriesDurationRequest": {
    "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#TimeEntriesDurationRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TimeEntriesDurationRequest()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#End",
      "tags": [
       "member",
       "property"
      ],
      "name": "End"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#Start",
      "tags": [
       "member",
       "property"
      ],
      "name": "Start"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentriesdurationrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TimeEntryDtoImpl": {
    "link": "clockify.net.models.timeentries.timeentrydtoimpl.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#TimeEntryDtoImpl",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TimeEntryDtoImpl()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#Billable",
      "tags": [
       "member",
       "property"
      ],
      "name": "Billable"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#Description",
      "tags": [
       "member",
       "property"
      ],
      "name": "Description"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#IsLocked",
      "tags": [
       "member",
       "property"
      ],
      "name": "IsLocked"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#TagIds",
      "tags": [
       "member",
       "property"
      ],
      "name": "TagIds"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#TaskId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TaskId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#TimeInterval",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeInterval"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#UserId",
      "tags": [
       "member",
       "property"
      ],
      "name": "UserId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentrydtoimpl.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TimeEntryRequest": {
    "link": "clockify.net.models.timeentries.timeentryrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#TimeEntryRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TimeEntryRequest()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#Billable",
      "tags": [
       "member",
       "property"
      ],
      "name": "Billable"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#Description",
      "tags": [
       "member",
       "property"
      ],
      "name": "Description"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#End",
      "tags": [
       "member",
       "property"
      ],
      "name": "End"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#ID",
      "tags": [
       "member",
       "property"
      ],
      "name": "ID"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#IsLocked",
      "tags": [
       "member",
       "property"
      ],
      "name": "IsLocked"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#Start",
      "tags": [
       "member",
       "property"
      ],
      "name": "Start"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#TagIds",
      "tags": [
       "member",
       "property"
      ],
      "name": "TagIds"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#TaskId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TaskId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#TimeInterval",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeInterval"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#UserId",
      "tags": [
       "member",
       "property"
      ],
      "name": "UserId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#WorkspaceId",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceId"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.timeentries.timeentryrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "TimeIntervalDto": {
    "link": "clockify.net.models.timeentries.timeintervaldto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#TimeIntervalDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "TimeIntervalDto()"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#Duration",
      "tags": [
       "member",
       "property"
      ],
      "name": "Duration"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#End",
      "tags": [
       "member",
       "property"
      ],
      "name": "End"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#Start",
      "tags": [
       "member",
       "property"
      ],
      "name": "Start"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.timeentries.timeintervaldto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "UpdateTimeEntryRequest": {
    "link": "clockify.net.models.timeentries.updatetimeentryrequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#UpdateTimeEntryRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "UpdateTimeEntryRequest()"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#Billable",
      "tags": [
       "member",
       "property"
      ],
      "name": "Billable"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#Description",
      "tags": [
       "member",
       "property"
      ],
      "name": "Description"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#End",
      "tags": [
       "member",
       "property"
      ],
      "name": "End"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#ProjectId",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectId"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#Start",
      "tags": [
       "member",
       "property"
      ],
      "name": "Start"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#TagIds",
      "tags": [
       "member",
       "property"
      ],
      "name": "TagIds"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#TaskId",
      "tags": [
       "member",
       "property"
      ],
      "name": "TaskId"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.timeentries.updatetimeentryrequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Users": {
  "link": "clockify.net.models.users.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "CurrentUserDto": {
    "link": "clockify.net.models.users.currentuserdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.currentuserdto.html#CurrentUserDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "CurrentUserDto()"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#ActiveWorkspace",
      "tags": [
       "member",
       "property"
      ],
      "name": "ActiveWorkspace"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#DefaultWorkspace",
      "tags": [
       "member",
       "property"
      ],
      "name": "DefaultWorkspace"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Email",
      "tags": [
       "member",
       "property"
      ],
      "name": "Email"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Memberships",
      "tags": [
       "member",
       "property"
      ],
      "name": "Memberships"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#ProfilePicture",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProfilePicture"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Settings",
      "tags": [
       "member",
       "property"
      ],
      "name": "Settings"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Status",
      "tags": [
       "member",
       "property"
      ],
      "name": "Status"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.currentuserdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "DashboardSelection": {
    "link": "clockify.net.models.users.dashboardselection.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.dashboardselection.html#Me",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Me"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#Team",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Team"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.users.dashboardselection.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   },
   "DashboardViewType": {
    "link": "clockify.net.models.users.dashboardviewtype.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#Billability",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Billability"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#Project",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Project"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.users.dashboardviewtype.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   },
   "SummaryReportSettingsDto": {
    "link": "clockify.net.models.users.summaryreportsettingsdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#SummaryReportSettingsDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "SummaryReportSettingsDto()"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#Group",
      "tags": [
       "member",
       "property"
      ],
      "name": "Group"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#Subgroup",
      "tags": [
       "member",
       "property"
      ],
      "name": "Subgroup"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.summaryreportsettingsdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "UserDto": {
    "link": "clockify.net.models.users.userdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.userdto.html#UserDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "UserDto()"
     },
     {
      "link": "clockify.net.models.users.userdto.html#ActiveWorkspace",
      "tags": [
       "member",
       "property"
      ],
      "name": "ActiveWorkspace"
     },
     {
      "link": "clockify.net.models.users.userdto.html#DefaultWorkspace",
      "tags": [
       "member",
       "property"
      ],
      "name": "DefaultWorkspace"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Email",
      "tags": [
       "member",
       "property"
      ],
      "name": "Email"
     },
     {
      "link": "clockify.net.models.users.userdto.html#ID",
      "tags": [
       "member",
       "property"
      ],
      "name": "ID"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Memberships",
      "tags": [
       "member",
       "property"
      ],
      "name": "Memberships"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.users.userdto.html#ProfilePicture",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProfilePicture"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Settings",
      "tags": [
       "member",
       "property"
      ],
      "name": "Settings"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Status",
      "tags": [
       "member",
       "property"
      ],
      "name": "Status"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.userdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.userdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.userdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.userdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.userdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "UserSettingsDto": {
    "link": "clockify.net.models.users.usersettingsdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.usersettingsdto.html#UserSettingsDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "UserSettingsDto()"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#CollapseAllProjectLists",
      "tags": [
       "member",
       "property"
      ],
      "name": "CollapseAllProjectLists"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#DashboardPinToTop",
      "tags": [
       "member",
       "property"
      ],
      "name": "DashboardPinToTop"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#DashboardSelection",
      "tags": [
       "member",
       "property"
      ],
      "name": "DashboardSelection"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#DashboardViewType",
      "tags": [
       "member",
       "property"
      ],
      "name": "DashboardViewType"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#DateFormat",
      "tags": [
       "member",
       "property"
      ],
      "name": "DateFormat"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#IsCompactViewOn",
      "tags": [
       "member",
       "property"
      ],
      "name": "IsCompactViewOn"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#LongRunning",
      "tags": [
       "member",
       "property"
      ],
      "name": "LongRunning"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#ProjectListCollapse",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectListCollapse"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#SendNewsletter",
      "tags": [
       "member",
       "property"
      ],
      "name": "SendNewsletter"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#SummaryReportSettingsDto",
      "tags": [
       "member",
       "property"
      ],
      "name": "SummaryReportSettingsDto"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#TimeFormat",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeFormat"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#TimeTrackingManual",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeTrackingManual"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#TimeZone",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeZone"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#Week",
      "tags": [
       "member",
       "property"
      ],
      "name": "Week"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#WeeklyUpdates",
      "tags": [
       "member",
       "property"
      ],
      "name": "WeeklyUpdates"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.usersettingsdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "UserStatus": {
    "link": "clockify.net.models.users.userstatus.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.userstatus.html#Active",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Active"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#Deleted",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Deleted"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#PendingEmailVerification",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "PendingEmailVerification"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.users.userstatus.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   },
   "Week": {
    "link": "clockify.net.models.users.week.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.users.week.html#Friday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Friday"
     },
     {
      "link": "clockify.net.models.users.week.html#Monday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Monday"
     },
     {
      "link": "clockify.net.models.users.week.html#Saturday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Saturday"
     },
     {
      "link": "clockify.net.models.users.week.html#Sunday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Sunday"
     },
     {
      "link": "clockify.net.models.users.week.html#Thursday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Thursday"
     },
     {
      "link": "clockify.net.models.users.week.html#Tuesday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Tuesday"
     },
     {
      "link": "clockify.net.models.users.week.html#Wednesday",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Wednesday"
     },
     {
      "link": "clockify.net.models.users.week.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.users.week.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.users.week.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.users.week.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.users.week.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.users.week.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.users.week.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.users.week.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.users.week.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.users.week.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.users.week.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.users.week.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   }
  }
 },
 "Clockify.Net.Models.Workspaces": {
  "link": "clockify.net.models.workspaces.html",
  "tags": [
   "namespace"
  ],
  "types": {
   "AdminOnlyPages": {
    "link": "clockify.net.models.workspaces.adminonlypages.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#Project",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Project"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#Reports",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Reports"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#Team",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Team"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.workspaces.adminonlypages.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   },
   "AutomaticClockDto": {
    "link": "clockify.net.models.workspaces.automaticclockdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#AutomaticClockDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "AutomaticClockDto()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#ChangeDay",
      "tags": [
       "member",
       "property"
      ],
      "name": "ChangeDay"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#DayOfMonth",
      "tags": [
       "member",
       "property"
      ],
      "name": "DayOfMonth"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#FirstDay",
      "tags": [
       "member",
       "property"
      ],
      "name": "FirstDay"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#OlderThanPeriod",
      "tags": [
       "member",
       "property"
      ],
      "name": "OlderThanPeriod"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#OlderThanValue",
      "tags": [
       "member",
       "property"
      ],
      "name": "OlderThanValue"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#Type",
      "tags": [
       "member",
       "property"
      ],
      "name": "Type"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclockdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "AutomaticClockType": {
    "link": "clockify.net.models.workspaces.automaticclocktype.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#Monthly",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Monthly"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#OlderThan",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "OlderThan"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#Weekly",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Weekly"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.workspaces.automaticclocktype.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   },
   "OlderThanPeriod": {
    "link": "clockify.net.models.workspaces.olderthanperiod.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#Days",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Days"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#Months",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Months"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#Weeks",
      "tags": [
       "member",
       "static",
       "field"
      ],
      "name": "Weeks"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#CompareTo(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "CompareTo(object target)"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#GetTypeCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetTypeCode()"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#HasFlag(System.Enum)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "HasFlag(enum flag)"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#ToString(System.String,System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format, IFormatProvider provider)"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#ToString(System.String)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(string format)"
     },
     {
      "link": "clockify.net.models.workspaces.olderthanperiod.html#ToString(System.IFormatProvider)",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString(IFormatProvider provider)"
     }
    ]
   },
   "RoundDto": {
    "link": "clockify.net.models.workspaces.rounddto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.rounddto.html#RoundDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "RoundDto()"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#Minutes",
      "tags": [
       "member",
       "property"
      ],
      "name": "Minutes"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#Round",
      "tags": [
       "member",
       "property"
      ],
      "name": "Round"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.rounddto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "WorkspaceDto": {
    "link": "clockify.net.models.workspaces.workspacedto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#WorkspaceDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "WorkspaceDto()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#HourlyRate",
      "tags": [
       "member",
       "property"
      ],
      "name": "HourlyRate"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#Id",
      "tags": [
       "member",
       "property"
      ],
      "name": "Id"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#ImageUrl",
      "tags": [
       "member",
       "property"
      ],
      "name": "ImageUrl"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#Memberships",
      "tags": [
       "member",
       "property"
      ],
      "name": "Memberships"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#WorkspaceSettings",
      "tags": [
       "member",
       "property"
      ],
      "name": "WorkspaceSettings"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacedto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "WorkspaceRequest": {
    "link": "clockify.net.models.workspaces.workspacerequest.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#WorkspaceRequest",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "WorkspaceRequest()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#Name",
      "tags": [
       "member",
       "property"
      ],
      "name": "Name"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacerequest.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   },
   "WorkspaceSettingsDto": {
    "link": "clockify.net.models.workspaces.workspacesettingsdto.html",
    "tags": [
     "type"
    ],
    "members": [
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#WorkspaceSettingsDto",
      "tags": [
       "member",
       "constructor"
      ],
      "name": "WorkspaceSettingsDto()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#AdminOnlyPages",
      "tags": [
       "member",
       "property"
      ],
      "name": "AdminOnlyPages"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#AutomaticLock",
      "tags": [
       "member",
       "property"
      ],
      "name": "AutomaticLock"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#CanSeeTimeSheet",
      "tags": [
       "member",
       "property"
      ],
      "name": "CanSeeTimeSheet"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#DefaultBillableProjects",
      "tags": [
       "member",
       "property"
      ],
      "name": "DefaultBillableProjects"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ForceDescription",
      "tags": [
       "member",
       "property"
      ],
      "name": "ForceDescription"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ForceProjects",
      "tags": [
       "member",
       "property"
      ],
      "name": "ForceProjects"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ForceTags",
      "tags": [
       "member",
       "property"
      ],
      "name": "ForceTags"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ForceTasks",
      "tags": [
       "member",
       "property"
      ],
      "name": "ForceTasks"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#LockTimeEntries",
      "tags": [
       "member",
       "property"
      ],
      "name": "LockTimeEntries"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#OnlyAdminsCreateProject",
      "tags": [
       "member",
       "property"
      ],
      "name": "OnlyAdminsCreateProject"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#OnlyAdminsCreateTag",
      "tags": [
       "member",
       "property"
      ],
      "name": "OnlyAdminsCreateTag"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#OnlyAdminsSeeAllTimeEntries",
      "tags": [
       "member",
       "property"
      ],
      "name": "OnlyAdminsSeeAllTimeEntries"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#OnlyAdminsSeeBillableRates",
      "tags": [
       "member",
       "property"
      ],
      "name": "OnlyAdminsSeeBillableRates"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#OnlyAdminsSeeDashboard",
      "tags": [
       "member",
       "property"
      ],
      "name": "OnlyAdminsSeeDashboard"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#OnlyAdminsSeePublicProjectsEntries",
      "tags": [
       "member",
       "property"
      ],
      "name": "OnlyAdminsSeePublicProjectsEntries"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ProjectFavorites",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectFavorites"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ProjectGroupingLabel",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectGroupingLabel"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ProjectPickerSpecialFilter",
      "tags": [
       "member",
       "property"
      ],
      "name": "ProjectPickerSpecialFilter"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#RoundDto",
      "tags": [
       "member",
       "property"
      ],
      "name": "RoundDto"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#TimeRoundingInReports",
      "tags": [
       "member",
       "property"
      ],
      "name": "TimeRoundingInReports"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#TrackTimeDownToSecond",
      "tags": [
       "member",
       "property"
      ],
      "name": "TrackTimeDownToSecond"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#Equals(System.Object)",
      "tags": [
       "member",
       "method",
       "virtual"
      ],
      "name": "Equals(object obj)"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#Finalize",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual"
      ],
      "name": "Finalize()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#GetHashCode",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetHashCode()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#GetType",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "GetType()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#MemberwiseClone",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "MemberwiseClone()"
     },
     {
      "link": "clockify.net.models.workspaces.workspacesettingsdto.html#ToString",
      "tags": [
       "member",
       "method",
       "virtual",
       "virtual",
       "virtual",
       "virtual"
      ],
      "name": "ToString()"
     }
    ]
   }
  }
 }
};
	/**@type {string[]} - The value to search for.*/
	let vals;
	/**@type {{
			only : string[],
			strictOnly : string[],
			exclude : string[],
			regex : string,
			acceptAll : boolean
		}} - The filter to exclude objects from the search.*/
	let filter;
	/**@type {string} - The id of the search bar.*/
	let searchBarId = "search-bar";
	/**@type {string} - The id of the search results window.*/
	let searchResultsId = "search-results";
	/**@type {string} - The id of the search help menu in the modal.*/
	let searchBarHelpId = "search-help-desc";
	/**@type {HTMLElement} - The list element that will be outputting the found results.*/
	let outputList;
	/**@type {HTMLElement} - The window element that will be toggled on and off whenever searching begins.*/
	let outputWindow;
	/**@type {number} - The id of the timeout function.*/
	let timeout;
	/**@type {number} - The index to the namespace to look into.*/
	let namespaceIndex;
	/**@type {number} - The index to the type to look into.*/
	let typeIndex;
	/**@type {number} - The index to the member to look into.*/
	let memberIndex;
	/**@type {string[]} - The list of namespaces used for searching.*/
	let namespaceList;
	/**@type {string[]} - The list of type used for searching.*/
	let typeList;
	/**@type {string} - The current namespace to search for first.*/
	let currNamespace;
	/**@type {string} - The current type to search for first.*/
	let currType;
	/**@type {string} - The name of the class that will pop the output window into focus.*/
	let outputWindowFocusClass = "active";
	/**@type {number} - The search interval.*/
	let searchInterval = 150;
	/**@type {number} - The starting search interval to make the user wait before the search starts.*/
	let startingSearchInterval = 250;
	/**@type {string} - The item that tells the user that it's searching.*/
	let searchingItem = '<li id="--searching-display-in-window--" style="text-align: center;">Searching...</li>';
	/**Sets the search interval. Make this number to small and you run the risk of freezing up the web app,
	 * this is to make the search pseudo-asynchronous.
	 * @param value {number} - The interval to wait between each iteration of the search.*/
	let setSearchInterval = function(value) { searchInterval = value; }
	/**Sets the starting search interval. Make this number to small and you run the risk of freezing up the web app,
	 * this is to make the search pseudo-asynchronous. This also stops the search bar from looking "glitchy".
	 * @param value {number} - The interval to wait before beginning the search.*/
	let setStartingSearchInterval = function(value) { startingSearchInterval = value; }
	/**Sets the output window's focus class to a specific class.
	 * @param value {string} - The new class that will make the output window appear.*/
	let setOutputWindowFocusClass = function(value) { outputWindowFocusClass = value; };
	/**Sets the current namespace and type to search for first.
	 * @param namespace {string} - The namespace to search for.
	 * @param type {string} - The type to search for.*/
	const setCurrent = function(namespace, type) {
		currNamespace = namespace;
		currType = type.replace(/</g, "&lt;").replace(/>/g, "&gt;");
	};
	/**Marks the result with a bolded mark of what the query string was.
	 * @param input {string} - The input string to mark.
	 * @param value {string} - The value string to mark win.
	 * @return {string} Returns the input string marked by the query string.*/
	const markResult = function(input, value) {
		// Variables
		let start = input.toLowerCase().indexOf(value);
		let end = start + value.length;
		
		return (
			input.substring(0, start) +
			"<b>" + input.substring(start, end) + "</b>" +
			input.substring(end)
		);
	};
	/**Starts searching through the API for anything similar to the given value.
	 * @param value {string} - The value used to query the API.
	 * @param windowId {string} - The id of the window to toggle on and off when searching.
	 * @param listId {string} - The id of the list to output the search results.*/
	const startSearch = function(value, windowId, listId) {
		if(timeout) {
			window.clearTimeout(timeout);
		}
		outputWindow = document.getElementById(windowId);
		if(value == "") {
			outputWindow.classList.remove(outputWindowFocusClass);
			return;
		}
		getValuesAndFilter(value);
		outputList = document.getElementById(listId);
		outputList.innerHTML = searchingItem;
		outputWindow.classList.add(outputWindowFocusClass);
		namespaceIndex = (currNamespace && currType ? -1 : 0);
		typeIndex = 0;
		memberIndex = 0;
		timeout = setTimeout(search, startingSearchInterval);
	};
	/**Gets the value and filter content from the given input value.
	 * @param value {string} - The input value from the user.*/
	const getValuesAndFilter = function(value) {
		// Variables
		const temp = value.toLowerCase().trim().replace(/</g, "&lt;").replace(/>/g, "&gt;").split(' ');
		let index = -1;
		
		vals = [];
		filter = {};
		
		for(let i = 0; i < temp.length; i++) {
			index = temp[i].indexOf(':');
			
			if(index == -1) {
				vals.push(temp[i]);
			}
			else {
				switch(temp[i].substring(0, index)) {
					case "only": {
						if(!filter.only) {
							filter.only = [];
						}
						filter.only = filter.only.concat(
							temp[i].substring(index + 1).split(',')
						);
					} break;
					case "strict-only": {
						if(!filter.strictOnly) {
							filter.strictOnly = [];
						}
						filter.strictOnly = filter.strictOnly.concat(
							temp[i].substring(index + 1).split(',')
						);
					} break;
					case "exclude": {
						if(!filter.exclude) {
							filter.exclude = [];
						}
						filter.exclude = filter.exclude.concat(
							temp[i].substring(index + 1).split(',')
						);
					} break;
					case "regex": {
						filter.regex = temp[i].substring(index + 1);
					} break;
					case "accept-all": {
						filter.acceptAll = (temp[i].substring(index + 1) != "false");
					} break;
				}
			}
		}
		
		if(vals.length == 0 && (!filter.regex || filter.regex == "") && filter.acceptAll != false) {
			filter.acceptAll = true;
		}
	};
	/**Removes the searching item telling the user they are searching.
	 * @return Returns true if the searching item was the only item and was promptly removed.*/
	const removeSearchingItem = function() {
		// Variables
		let searchingItem = document.getElementById("--searching-display-in-window--");
		
		if(searchingItem) {
			outputList.removeChild(searchingItem);
			return (outputList.innerHTML == "");
		}
		return false;
	};
	/**Finds if the current iteration of searching yields that it is the current type being viewed.
	 * Used to skip first search results of the current type.
	 * @returns Returns true if the current type is the one being viewed.*/
	const isCurrentType = function() {
		if(currNamespace && currType) {
			return (
				namespaceList[namespaceIndex] == currNamespace &&
				typeList[typeIndex] == currType
			);
		}
		return false;
	};
	/**Formats the outputted list item, customizable for end-user.
	 * @param values {string[]} - The values that the user has queried.
	 * @param regex {string} - The regular expression used to find a match.
	 * @param link {string} - The link to where the item will take the user.
	 * @param name {string} - The name of the namespace/type/member.
	 * @param markResult {markResult} - A function that marks the query string as bold onto the inputted string.*/
	let formatOutputListItem = function(values, regex, link, name, markResult) {
		// Variables
		let results = name;
		let regexStr = "";
		
		if(regex) {
			regexStr = regex;
		}
		if(values && values.length > 0) {
			regexStr = (
				(regexStr == "" ? "" : regexStr + "|") + 
				escapeRegex(values.join('|'))
			);
		}
		if(regexStr != "") {
			results = results.replace(
				new RegExp("(" + regexStr + ")", "gi"),
				"<b>$1</b>"
			);
		}
		
		return (
			'<li><a href="' + link + '">' +
			results +
			"</a></li>"
		);
	};
	/**Escapes the regex to safely use the characters: ., *, +, -, ?, ^, $, {, }, (, ), [, ], and \.
	 * @param regex {string} - The regex string to escape.
	 * @returns {string} Returns the escaped regex string.*/
	const escapeRegex = function(regex) { return regex.replace(/[.*+\-?$^{}()\[\]\\]/g, "\\$&"); }
	/**Sets a custom format output list item.
	 * @param func {formatOutputListItem} - The new formatting function to set.*/
	const setFormatOutputListItem = function(func) { formatOutputListItem = func; };
	/**Finds if the given value is fulfilling the criteria for accepting into the output list.
	 * @param tags {string} - The tags of membership the object is apart of.
	 * @param value {string} - The string to look into.
	 * @returns {boolean} Returns true if the given value fulfills the criteria for accepting into the output list.*/
	const isFulfillingCriteria = function(tags, value) {
		// Variables
		const lowerCaseValue = value.toLowerCase();
		
		if(filter.strictOnly) {
			for(let i = 0; i < filter.strictOnly.length; i++) {
				if(tags.indexOf(filter.strictOnly[i]) == -1) {
					return false;
				}
			}
		}
		if(filter.only) {
			// Variables
			let found = false;
			
			for(let i = 0; i < filter.only.length; i++) {
				if(tags.indexOf(filter.only[i]) != -1) {
					found = true;
					break;
				}
			}
			
			if(!found) { return false; }
		}
		if(filter.exclude) {
			// Variables
			let item;
			
			for(let i = 0; i < filter.exclude.length; i++) {
				item = filter.exclude[i]
				
				if(tags.indexOf(item) != -1) {
					return false;
				}
			}
		}
		
		if(filter.acceptAll == true) {
			return true;
		}
		
		if(filter.regex) {
			if(lowerCaseValue.match(new RegExp(filter.regex, "gi"))) {
				return true;
			}
		}
		
		for(let i = 0; i < vals.length; i++) {
			if(lowerCaseValue.match(new RegExp(escapeRegex(vals[i]), "gi"))) {
				return true;
			}
		}
		
		return false;
	};
	/**Searches through the entire API little by little.*/
	const search = function() {
		for(let i = 0; i < 100; i++) {
			if(!namespaceList && namespaceIndex == 0) {
				namespaceList = Object.keys(searchJson);
			}
			if(namespaceIndex >= 0 && typeIndex == 0) {
				typeList = Object.keys(searchJson[namespaceList[namespaceIndex]].types);
			}
		
			if(namespaceIndex == -1) {
				// Variables
				const namespace = searchJson[currNamespace];
				const type = namespace.types[currType];
				const member = type.members[memberIndex];
				let name;
				
				if(memberIndex == 0) {
					if(isFulfillingCriteria(namespace.tags, currNamespace)) {
						outputList.innerHTML += formatOutputListItem(
							vals,
							filter.regex,
							namespace.link,
							currNamespace,
							markResult
						);
					}
					name = currNamespace + "." + currType;
					if(isFulfillingCriteria(type.tags, name)) {
						outputList.innerHTML += formatOutputListItem(
							vals,
							filter.regex,
							type.link,
							name,
							markResult
						);
					}
				}
				
				name = currNamespace + "." + currType + "." + member.name;
				if(isFulfillingCriteria(member.tags, name)) {
					outputList.innerHTML += formatOutputListItem(
						vals,
						filter.regex,
						member.link,
						name,
						markResult
					);
				}
				
				memberIndex++;
				if(memberIndex >= type.members.length) {
					memberIndex = 0;
					namespaceIndex++;
				}
			}
			else {
				// Variables
				const namespace = searchJson[namespaceList[namespaceIndex]];
				const type = namespace.types[typeList[typeIndex]];
				const member = type.members[memberIndex];
				let name;
				
				if(typeIndex == 0 && memberIndex == 0) {
					if(!currNamespace || namespaceList[namespaceIndex] != currNamespace) {
						if(!isCurrentType() && namespace) {
							name = namespaceList[namespaceIndex];
							if(isFulfillingCriteria(namespace.tags, name)) {
								outputList.innerHTML += formatOutputListItem(
									vals,
									filter.regex,
									namespace.link,
									name,
									markResult
								);
							}
						}
					}
				}
				if(memberIndex == 0) {
					if(!isCurrentType()) {
						name = namespaceList[namespaceIndex] + "." + typeList[typeIndex];
						if(isFulfillingCriteria(type.tags, name)) {
							outputList.innerHTML += formatOutputListItem(
								vals,
								filter.regex,
								type.link,
								name,
								markResult
							);
						}
					}
				}
				
				if(!isCurrentType() && member) {
					name = namespaceList[namespaceIndex] + "." + typeList[typeIndex] + "." + member.name;
					if(isFulfillingCriteria(member.tags, name)) {
						outputList.innerHTML += formatOutputListItem(
							vals,
							filter.regex,
							member.link,
							name,
							markResult
						);
					}
				}
				
				memberIndex++;
				if(type) {
					if(memberIndex >= type.members.length) {
						memberIndex = 0;
						
						typeIndex++;
					}
				}
				else {
					memberIndex = 0;
					typeIndex++;
				}
				if(typeIndex >= typeList.length) {
					typeIndex = 0;
					namespaceIndex++;
				}
			}
			
			if(namespaceList && namespaceIndex >= namespaceList.length) {
				break;
			}
		}
		
		if(namespaceIndex == -1 || namespaceIndex < namespaceList.length) {
			timeout = setTimeout(search, searchInterval);
		}
		else {
			if(removeSearchingItem()) {
				outputList.innerHTML = '<li style="text-align: center;">No results found!</li>';
			}
		}
	};
	/**Sets the search ids for search bar and search results window.
	 * @param searchBarID {string} - The id of the search bar to set.
	 * @param searchResultsID {string} - The id of the search results to set.*/
	const setSearchIds = function(searchBarID, searchResultsID, searchBarHelpID) {
		searchBarId = searchBarID;
		searchResultsId = searchResultsID;
		searchBarHelpId = searchBarHelpID;
	};
	/**Gets the help text of the search bar.
	 * @returns {string} Returns the help text for the search bar.*/
	const getHelpText = function(escapeHtml = false) {
		// Variables
		let help = "You can filter the search by using the following qualifiers:";
		
		if(escapeHtml) { help += "<br/><br/>\n"; }
		else { help += "\n\n"; }
		
		if(escapeHtml) { help += '<kbd class="search-bar-help-name">strict-only</kbd>'; }
		else { help += "  strict-only"; }
		help += " - Use an array of namespace, type, member, constructor, field,\n";
		help += "    event, property, method, static, sealed, virtual, nested, or operator to filter out types of objects,\n";
		help += "    seperated by a comma ( , ). Each category must be met to be accepted as a\n";
		help += "    result.";
		if(escapeHtml) { help += "<br/>\n&emsp;"; }
		else { help += "\n      "; }
		help += "Example: ";
		if(escapeHtml) { help += '<kbd class="search-bar-help-desc">strict-only:static,method</kbd>'; }
		else { help += "strict-only:static,method" }
		
		if(escapeHtml) { help += "<br/><br/>\n"; }
		else { help += "\n\n"; }
		
		if(escapeHtml) { help += '<kbd class="search-bar-help-name">only</kbd>'; }
		else { help += "  only"; }
		help += " - Use an array of namespace, type, member, constructor, field,\n";
		help += "    event, property, method, static, sealed, virtual, nested, or operator to filter out types of objects,\n";
		help += "    seperated by a comma ( , ).";
		if(escapeHtml) { help += "<br/>\n&emsp;"; }
		else { help += "\n      "; }
		help += "Example: ";
		if(escapeHtml) { help += '<kbd class="search-bar-help-desc">only:type,namespace</kbd>'; }
		else { help += "only:type,namespace"; }
		
		if(escapeHtml) { help += "<br/><br/>\n"; }
		else { help += "\n\n"; }
		
		if(escapeHtml) { help += '<kbd class="search-bar-help-name">exclude</kbd>'; }
		else { help += "  exclude"; }
		help += " - Use namespace, type, and member to exclude those objects from search,\n";
		help += "    seperated by a comma ( , ).";
		if(escapeHtml) { help += "<br/>\n&emsp;"; }
		else { help += "\n      "; }
		help += "Example: ";
		if(escapeHtml) { help += '<kbd class="search-bar-help-desc">exclude:namespace,type</kbd>'; }
		else { help += "exclude:namespace,type" }
		
		if(escapeHtml) { help += "<br/><br/>\n"; }
		else { help += "\n\n"; }
		
		if(escapeHtml) { help += '<kbd class="search-bar-help-name">regex</kbd>'; }
		else { help += "  regex"; }
		help += " - Use this to search by using a regular expression string.";
		if(escapeHtml) { help += "<br/>\n&emsp;"; }
		else { help += "\n      "; }
		help += "Example: ";
		if(escapeHtml) { help += '<kbd class="search-bar-help-desc">regex:mat\\d+</kbd>'; }
		else { help += "regex:mat\\d+"; }
		
		if(escapeHtml) { help += "<br/><br/>\n"; }
		else { help += "\n\n"; }
		
		if(escapeHtml) { help += '<kbd class="search-bar-help-name">accept-all</kbd>'; }
		else { help += "  accept-all"; }
		help += " - Set this to true to search for every object.";
		if(escapeHtml) { help += "<br/>\n&emsp;"; }
		else { help += "\n      "; }
		help += "Example: ";
		if(escapeHtml) { help += '<kbd class="search-bar-help-desc">accept-all:true</kbd>'; }
		else { help += "accept-all:true"; }
		
		return help;
	};
	
	window.addEventListener("load", function() {
		// Variables
		let searchBar = document.getElementById(searchBarId);
		let searchHelp = document.getElementById(searchBarHelpId);
		
		if(!searchBar) { return; }
		
		searchBar.title = getHelpText();
		searchHelp.innerHTML = getHelpText(true);
	});
	
	window.addEventListener("click", function(args) {
		// Variables
		let target = args.target;
		let results = document.getElementById(searchResultsId);
		
		if(!results) { return; }
		
		if(target.tagName == "A" && target.href != "") {
			results.classList.remove(outputWindowFocusClass);
			return;
		}
		
		if(target.id == searchBarId && target.value != "") {
			results.classList.add(outputWindowFocusClass);
			return;
		}
		if(!results.classList.contains(outputWindowFocusClass)) {
			return;
		}
		
		while(target != null) {
			if(target.id == searchBarId || target.id == searchResultsId) {
				break;
			}
			target = target.parentElement;
		}
		
		if(target == null) {
			results.classList.remove(outputWindowFocusClass);
		}
	});
	
	return {
		setCurrent: setCurrent,
		search: startSearch,
		setFormatOutputListItem: setFormatOutputListItem,
		setOutputWindowFocusClass: setOutputWindowFocusClass,
		setSearchInterval: setSearchInterval,
		setStartingSearchInterval: setStartingSearchInterval,
		setSearchIds: setSearchIds,
		getHelpText: getHelpText
	};
})();
