
using System.IO;

namespace Clockify.Net.Execution.Members.AddPhoto;

public class MemberAddPhotoRequestBuilder : IExecutingRequestBuilder<MemberAddPhotoRequest>
{
    private readonly MemberAddPhotoRequest _request = new MemberAddPhotoRequest();
    public MemberAddPhotoRequestBuilder WithFile(byte[] file)
    {
        // Implementation for adding a photo with the provided file bytes
        _request.Photo = new MemoryStream(file);
        return this;
    }

    public MemberAddPhotoRequestBuilder WithFilePath(string filePath)
    {
        _request.Photo = new MemoryStream(File.ReadAllBytes(filePath));
        // Implementation for adding a photo with the provided file path
        return this;
    }

    public MemberAddPhotoRequestBuilder WithFile(FileStream fileStream)
    {
        // Implementation for adding a photo with the provided file stream
        fileStream.CopyTo(_request.Photo);
        return this;
    }

    public MemberAddPhotoRequestBuilder WithFile(Stream stream)
    {
        // Implementation for adding a photo with the provided stream
        stream.CopyTo(_request.Photo);
        return this;
    }

    public MemberAddPhotoRequest Request => _request;
}