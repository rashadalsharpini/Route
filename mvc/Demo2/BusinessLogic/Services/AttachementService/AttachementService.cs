using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.AttachementService;

public class AttachementService: IAttachementService
{
    private List<string> allowedExtensions = [".jpg", ".png", ".jpeg"];
    private const int maxSize = 1024 * 1024 * 2;
    public string? Upload(IFormFile file, string folderName)
    {
        var extension = Path.GetExtension(file.FileName);
        if (!allowedExtensions.Contains(extension)) return null;
        if (file.Length > maxSize || file.Length == 0) return null;
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folderName);
        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(folderPath, fileName);
        using FileStream fs = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fs);
        return fileName;
    }

    public bool Delete(string filePath)
    {
        if (!File.Exists(filePath))
            return false;
        File.Delete(filePath);
        return true;
    }
}