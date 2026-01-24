using System.IO;

using Clockify.Net.Execution;

public class MemberAddPhotoRequest : IRequest<MemberAddPhotoResponse>
{
    public MemoryStream Photo { get; set; }    
}
