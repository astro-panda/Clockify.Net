
using System.IO;

using Clockify.Net.Models;

namespace Clockify.Net;

public class MemberAddPhotoRequestBuilder
{
    public RequestExecutor WithFile(byte[] file)
    {
        // Implementation for adding a photo with the provided file bytes
        return new RequestExecutor();
    }

    public RequestExecutor< WithFilePath(string filePath)
    {
        // Implementation for adding a photo with the provided file path
    }

    public RequestExecutor WithFile(FileStream fileStream)
    {
        // Implementation for adding a photo with the provided file stream
        return new RequestExecutor();
    }

    public RequestExecutor WithFile(Stream stream)
    {
        // Implementation for adding a photo with the provided stream
        return new RequestExecutor();
    }
}