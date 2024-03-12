using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Reflection.Metadata;

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
            var blobClient = containerClient.GetBlobClient(guid + ";" + file.Name);
            var fileStream = file.OpenReadStream();
            await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
            var metadata = new Dictionary<string, string> { { "Email", email } };
            await blobClient.SetMetadataAsync(metadata);
        }
    }
}
