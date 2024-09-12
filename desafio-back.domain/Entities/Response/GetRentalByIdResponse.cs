namespace desafio_back.domain.Entities.Response
{
    public class GetRentalByIdResponse : IDomainResponse
    {
        public string? Identificador { get; set; }
        public string? Valor_diaria { get; set; }
        public string? Entregador_Id { get; set; }
        public string? Moto_Id { get; set; }
        public string? Data_inicio { get; set; }
        public string? Data_termino { get; set; }
        public string? Data_previsao_termino { get; set; }
        public string? Data_devolucao { get; set; }
    }
}
