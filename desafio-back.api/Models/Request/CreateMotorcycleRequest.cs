namespace desafio_back.api.Models.Request
{
    public record CreateMotorcycleRequest(string? Identificador, int Ano, string? Modelo, string? Placa);
}
