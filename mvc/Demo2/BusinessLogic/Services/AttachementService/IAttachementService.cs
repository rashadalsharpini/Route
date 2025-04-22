using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.AttachementService;

public interface IAttachementService
{
    public string? Upload(IFormFile file, string folderName);
    public bool Delete(string filePath);
}