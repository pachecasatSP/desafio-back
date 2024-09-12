using desafio_back.api.Services;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Abstractions.SatteliteServices;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.Constants;
using desafio_back.domain.Entities.DomainEntities;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace desafio_back.domain.Services;

public class DeliverymanService : ServiceBase<DeliveryMan>, IDeliverymanService
{
    private readonly IDeliveryManBlobStorageService _blobStorageClient;

    public DeliverymanService(IDeliveryManRepository repository,
                              IDeliveryManBlobStorageService blobStorageClient)
    {
        _repository = repository;
        _blobStorageClient = blobStorageClient;
    }

    public async Task<bool> IsAllowedCNHType(string cnhType) =>
           await CNHTypes.IsAccepted(cnhType);
    public async Task<bool> CnpjDoesNotExists(string cnpj) =>
            await FirstOrDefaultAsync(x => x.Cnpj == cnpj) is null;
    public async Task<bool> DriverLicenseDoesNotExits(string driverLicenseNumber) =>
            await FirstOrDefaultAsync(x => x.CNHNumber == driverLicenseNumber) is null;

    public async Task<bool> IdDoesNotExists(string identificador) =>
            await FirstOrDefaultAsync(x => x.Id == identificador) is null;
    public async Task<bool> IdExists(string identificador) =>
           await FirstOrDefaultAsync(x => x.Id == identificador) != null;

    public async Task<bool> IsAllowedCnhImageFormat(byte[] bytes) =>
        await AcceptedCNHImageFormats.IsAccepted(bytes);

    public async Task<bool> SaveDriverLicenseImageAsync(string? driverlicenseImage, int deliveryManInternalId)
    {
        var data = Convert.FromBase64String(driverlicenseImage!);
        await _blobStorageClient.SaveDriverLicenseImageToBlobAsync(deliveryManInternalId.ToString(), data);
        return true;
    }

    public override async Task<DeliveryMan> FirstOrDefaultAsync(Expression<Func<DeliveryMan, bool>> predicate) =>
        await _repository!.FirstOrDefaultAsync(predicate);

    public async Task<bool> IsValidCnpj(string cnpj)
    {
        cnpj = Regex.Replace(cnpj, @"[^\d]", "");

        if (cnpj.Length != 14)
            return false;

        if (new Regex(@"^(\d)\1*$").IsMatch(cnpj))
            return false;

        int[] weights1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int sum1 = 0;
        for (int i = 0; i < 12; i++)
        {
            sum1 += (cnpj[i] - '0') * weights1[i];
        }
        int remainder1 = sum1 % 11;
        int digit1 = remainder1 < 2 ? 0 : 11 - remainder1;

        int[] weights2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int sum2 = 0;
        for (int i = 0; i < 13; i++)
        {
            sum2 += (cnpj[i] - '0') * weights2[i];
        }
        int remainder2 = sum2 % 11;
        int digit2 = remainder2 < 2 ? 0 : 11 - remainder2;

        return cnpj.EndsWith($"{digit1}{digit2}");
    }


}
