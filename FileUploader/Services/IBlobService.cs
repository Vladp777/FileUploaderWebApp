using Microsoft.AspNetCore.Components.Forms;

namespace FileUploader.Services
{
    public interface IBlobService
    {
        Task UploadFileAsync(IBrowserFile file, string email);
    }
}