using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Versioning;


namespace FlyNest.SharedKernel.Core.CustomValidation;

[SupportedOSPlatform("windows")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class ImageFileValidationAttribute(int minFileSize, int maxFileSize, int minWidth, int maxWidth, int minHeight, int maxHeight) : ValidationAttribute
{
    public int MaxFileSize { get; } = maxFileSize;
    public int MinFileSize { get; } = minFileSize;
    public int MinWidth { get; } = minWidth;
    public int MaxWidth { get; } = maxWidth;
    public int MinHeight { get; } = minHeight;
    public int MaxHeight { get; } = maxHeight;

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Image is required.");
        }

        if (value is IFormFile file)
        {
            if (file.Length < MinFileSize)
            {
                return new ValidationResult($"File size must be greater than {MinFileSize / 1024} KB");
            }

            if (file.Length > MaxFileSize)
            {
                return new ValidationResult($"File size should be up to {MaxFileSize / (1024 * 1024)} MB.");
            }
            using var image = Image.FromStream(file.OpenReadStream());
            if (image.Width < MinWidth || image.Height < MinHeight ||
                        image.Width > MaxWidth || image.Height > MaxHeight)
            {
                return new ValidationResult($"Image dimensions should be between {MinWidth}x{MinHeight} and {MaxWidth}x{MaxHeight} pixels.");
            }
        }

        return ValidationResult.Success;
    }
}