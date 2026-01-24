using System.IO;

namespace Clockify.Net.Execution.Members.AddPhoto;

public interface IMemberAddPhotoService : IRequestService<MemberAddPhotoRequest, MemberAddPhotoResponse>
{
    IMemberAddPhotoService WithFile(byte[] file);
    IMemberAddPhotoService WithFile(FileStream fileStream);
    IMemberAddPhotoService WithFile(Stream stream);
    IMemberAddPhotoService WithFilePath(string filePath);
}
