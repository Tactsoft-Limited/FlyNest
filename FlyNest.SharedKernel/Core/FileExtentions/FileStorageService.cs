using FlyNest.SharedKernel.Core.Default;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FlyNest.SharedKernel.Core.FileExtentions;

public class FileStorageService : IFileStorageService
{
    private readonly string _imagesPath;
    private readonly string _documentsPath;

    public FileStorageService(IWebHostEnvironment webHostEnvironment)
    {
        _imagesPath = Path.Combine(webHostEnvironment.WebRootPath, CommonVariables.PictureLocation);
        _documentsPath = Path.Combine(webHostEnvironment.WebRootPath, CommonVariables.DocumentsLocation);
        EnsureDirectoryExists(_imagesPath);
        EnsureDirectoryExists(_documentsPath);
    }



    public async Task<string> SaveImageAsync(IFormFile imageFile)
    { return await SaveFileAsync(imageFile, _imagesPath); }

    public async Task<string> SaveDocumentAsync(IFormFile documentFile)
    { return await SaveFileAsync(documentFile, _documentsPath); }

    public async Task<string> UpdateImageAsync(string existingFileName, IFormFile newImageFile)
    { return await UpdateFileAsync(existingFileName, newImageFile, _imagesPath); }

    public async Task<string> UpdateDocumentAsync(string existingFileName, IFormFile newDocumentFile)
    { return await UpdateFileAsync(existingFileName, newDocumentFile, _documentsPath); }

    public void RemoveFile(string fileName)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            DeleteFile(fileName, _imagesPath);
        }
    }

    public async Task RemoveFileAsync(string fileName)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            await Task.Run(() => DeleteFile(fileName, _imagesPath));
        }
    }

    private static async Task<string> SaveFileAsync(IFormFile file, string folderPath)
    {
        if (file == null || file.Length == 0)
        {
            return null;
        }

        var fileName = GenerateUniqueFileName(file);
        var filePath = Path.Combine(folderPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return fileName;
    }

    private static async Task<string> UpdateFileAsync(string existingFileName, IFormFile newFile, string folderPath)
    {
        if (newFile == null || newFile.Length == 0)
        {
            return existingFileName;
        }
        if (existingFileName != null)
        {
            DeleteFile(existingFileName, folderPath);
        }

        return await SaveFileAsync(newFile, folderPath);
    }

    private static string GenerateUniqueFileName(IFormFile file)
    { return $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"; }

    private static void DeleteFile(string fileName, string folderPath)
    {
        var filePath = Path.Combine(folderPath, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    private static void EnsureDirectoryExists(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
}
