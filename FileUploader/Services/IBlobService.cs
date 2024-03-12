using Microsoft.AspNetCore.Components.Forms;

namespace FileUploader.Services
{
    public interface IBlobService
    {
        Task UploadFileAsync(IBrowserFile file, string email);
        Task<string> UploadFileAsync(string fileName, Stream stream, string type);

        Task UploadFileAsync(IBrowserFile file, Stream stream, string email);
    }
}