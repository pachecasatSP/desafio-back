namespace desafio_back.api.Models.Request
{
    public record CreateDeliveryManRequest(string? Identificador, string? Nome, string? Cnpj,
                                           DateTime DataNascimento, string? NumeroCnh, string? TipoCnh);
}
