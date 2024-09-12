using desafio_back.domain.Entities.DomainEntities;

namespace desafio_back.domain.Abstractions.Services
{
    public interface IDeliverymanService : IService<DeliveryMan>
    {
        Task<bool> IsAllowedCNHType(string cnhType);
        Task<bool> CnpjDoesNotExists(string cnpj);
        Task<bool> DriverLicenseDoesNotExits(string driverLicenseNumber);
        Task<bool> IsAllowedCnhImageFormat(byte[] bytes);
        Task<bool> SaveDriverLicenseImageAsync(string? driverlicenseImage, int deliveryManInternalId);
        Task<bool> IsValidCnpj(string cnpj);
        Task<bool> IdDoesNotExists(string Identificador);
        Task<bool> IdExists(string Identificador);
    }
}
