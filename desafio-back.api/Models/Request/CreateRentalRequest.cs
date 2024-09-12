namespace desafio_back.api.Models.Request
{
    public record CreateRentalRequest(string? Entregador_id, string? Moto_id, DateTime Data_inicio,
                                      DateTime Data_termino, DateTime Data_previsao_termino, int Plano);
}
