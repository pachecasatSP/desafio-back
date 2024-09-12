using Azure.Storage.Blobs;
using desafio_back.domain.Abstractions.Services;

namespace desafio_back.infrastructure.SatteliteServices.BlobStorage
{
    public class AzureBlobStorageClient : IBlobStorageClient
    {
        private BlobServiceClient _client;

        private const string CONTAINERNAME = "desafio-back";

        public AzureBlobStorageClient(string connectionString) =>
            _client = new BlobServiceClient(connectionString);

        public async Task<bool> WriteToBlobAsync(byte[] data, string blobName)
        {
            try
            {
                var containerClient = _client.GetBlobContainerClient(CONTAINERNAME);
                await containerClient.CreateIfNotExistsAsync();

                var blobClient = containerClient.GetBlobClient(blobName);
                using var ms = new MemoryStream(data);
                await blobClient.UploadAsync(ms);
                return true;
            }
            catch
            {
                return false;
                throw;
            }

        }
    }
}
