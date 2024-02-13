using Microsoft.AspNetCore.Http;

namespace FlyNest.SharedKernel.Core.FileExtentions;

public interface IFileStorageService
{
    Task<string> SaveImageAsync(IFormFile imageFile);

    Task<string> SaveDocumentAsync(IFormFile documentFile);

    Task<string> UpdateImageAsync(string existingFileName, IFormFile newImageFile);

    Task<string> UpdateDocumentAsync(string existingFileName, IFormFile newDocumentFile);

    void RemoveFile(string fileName);
}
