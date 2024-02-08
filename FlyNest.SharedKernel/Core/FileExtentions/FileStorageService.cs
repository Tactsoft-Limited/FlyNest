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
        _imagesPath = Path.Combine(webHostEnvironment.WebRootPath, CommonVariables.TourPackageImageLocation);
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

    private async Task<string> SaveFileAsync(IFormFile file, string folderPath)
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

    private async Task<string> UpdateFileAsync(string existingFileName, IFormFile newFile, string folderPath)
    {
        if (newFile == null || newFile.Length == 0)
        {
            return existingFileName;
        }
        if (existingFileName != null)
        {
            // Delete the existing file
            DeleteFile(existingFileName, folderPath);
        }
        // Save the new file
        return await SaveFileAsync(newFile, folderPath);
    }

    // Helper method to generate a unique file name
    private string GenerateUniqueFileName(IFormFile file)
    { return $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"; }

    // Helper method to delete a file
    private void DeleteFile(string fileName, string folderPath)
    {
        var filePath = Path.Combine(folderPath, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    private void EnsureDirectoryExists(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
}
