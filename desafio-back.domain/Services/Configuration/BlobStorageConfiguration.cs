namespace desafio_back.domain.Services.Configuration;

public record BlobStorageConfiguration(string ConnectionString)
{
    public const string BlobStorage = "BlobStorage";
}
