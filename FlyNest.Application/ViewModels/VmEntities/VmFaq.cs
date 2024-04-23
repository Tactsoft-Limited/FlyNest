using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmFaq : BaseEntity
{
    [Required(ErrorMessage = "Category is required.")]
    [StringLength(100, ErrorMessage = "Category length must be less than or equal to 100 characters.")]
    public string Category { get; set; }

    [Required(ErrorMessage = "Question is required.")]
    [StringLength(300, ErrorMessage = "Question length must be less than or equal to 300 characters.")]
    public string Question { get; set; }

    [Required(ErrorMessage = "Answer is required.")]
    [StringLength(1000, ErrorMessage = "Answer length must be less than or equal to 1000 characters.")]
    public string Answer { get; set; }
}
