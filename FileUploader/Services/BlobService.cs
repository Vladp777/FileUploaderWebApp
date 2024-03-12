using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace FileUploader.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task UploadFileAsync(IBrowserFile file, string email)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("fileuploader");
            var guid = Guid.NewGuid();
            var blobClient = containerClient.GetBlobClient(email + "-" + file.Name);
            var f = file.OpenReadStream();
            var result = await blobClient.UploadAsync(f, new BlobHttpHeaders { ContentType = file.ContentType });
        }
        public async Task UploadFileAsync(IBrowserFile file, Stream stream, string email)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("fileuploader");
            var guid = Guid.NewGuid();
            var blobClient = containerClient.GetBlobClient(email + "-" + file.Name);
            var result = await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
        }
    }
}
