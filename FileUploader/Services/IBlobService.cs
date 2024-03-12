using Microsoft.AspNetCore.Components.Forms;

namespace FileUploader.Services
{
    public interface IBlobService
    {
        Task UploadFileAsync(IBrowserFile file, string email);
        Task UploadFileAsync(IBrowserFile file, Stream stream, string email);
    }
}