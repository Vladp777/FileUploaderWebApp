using Syncfusion.Blazor.Inputs;
using System.ComponentModel.DataAnnotations;

namespace FileUploader.Models;

public class UploadModel
{
    [Required]
    [EmailAddress]
    public string Email {  get; set; }

    [Required(ErrorMessage = "Please upload a file")]
    public UploadFiles File { get; set; }


}
