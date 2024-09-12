namespace desafio_back.domain.Abstractions.SatteliteServices
{
    public interface IDeliveryManBlobStorageService
    {
        Task<bool> SaveDriverLicenseImageToBlobAsync(string id, byte[] data);
    }
}
