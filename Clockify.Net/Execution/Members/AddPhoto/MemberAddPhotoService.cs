
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Clockify.Net.Execution.Members.AddPhoto;

public class MemberAddPhotoService : ClockifyRequestBuilder, IMemberAddPhotoService
{
    private readonly MemberAddPhotoRequest _request = new MemberAddPhotoRequest();
    public IMemberAddPhotoService WithFile(byte[] file)
    {
        // Implementation for adding a photo with the provided file bytes
        _request.Photo = new MemoryStream(file);
        return this;
    }

    public IMemberAddPhotoService WithFilePath(string filePath)
    {
        _request.Photo = new MemoryStream(File.ReadAllBytes(filePath));
        // Implementation for adding a photo with the provided file path
        return this;
    }

    public IMemberAddPhotoService WithFile(FileStream fileStream)
    {
        // Implementation for adding a photo with the provided file stream
        fileStream.CopyTo(_request.Photo);
        return this;
    }

    public IMemberAddPhotoService WithFile(Stream stream)
    {
        // Implementation for adding a photo with the provided stream
        stream.CopyTo(_request.Photo);
        return this;
    }

    public Task<Result<MemberAddPhotoResponse>> SendAsync(CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }

    public MemberAddPhotoRequest Request => _request;
}