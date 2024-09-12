using desafio_back.domain.Abstractions.SatteliteServices;
using desafio_back.domain.Abstractions.Services;

namespace desafio_back.api.Services
{
    public class DeliveryManBlobStorageService : IDeliveryManBlobStorageService
    {
        private IBlobStorageClient _blobStorageClient;

        private const string DRIVERLICENSEBLOBNAME = "driverlicenseImages";

        public DeliveryManBlobStorageService(IBlobStorageClient blobStorageClient) =>
                _blobStorageClient = blobStorageClient;

        public async Task<bool> SaveDriverLicenseImageToBlobAsync(string id, byte[] data) =>
            await _blobStorageClient.WriteToBlobAsync(data, $"{DRIVERLICENSEBLOBNAME}/{id}");
    }
}
