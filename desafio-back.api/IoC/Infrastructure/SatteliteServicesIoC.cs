using desafio_back.api.Services;
using desafio_back.domain.Abstractions.SatteliteServices;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Services.Configuration;
using desafio_back.infrastructure.SatteliteServices.BlobStorage;

namespace desafio_back.api.IoC.Infrastructure;

public static class SatteliteServicesIoC
{
    public static void RegisterSatelliteServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IBlobStorageClient>(new AzureBlobStorageClient(configuration.GetConnectionString(BlobStorageConfiguration.BlobStorage)!));
        services.AddSingleton<IDeliveryManBlobStorageService, DeliveryManBlobStorageService>();

    }
}
