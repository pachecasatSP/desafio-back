namespace desafio_back.domain.Abstractions.Services
{
    public interface IBlobStorageClient
    {
        Task<bool> WriteToBlobAsync(byte[] data, string blobName);
    }
}
