using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace FileUploader.Models;

public class UploadModel
{
    [Required]
    [EmailAddress]
    public string Email {  get; set; }

    [Required(ErrorMessage = "Please upload a file")]
    public IReadOnlyList<IBrowserFile>? Files { get; set; }


}
