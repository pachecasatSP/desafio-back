namespace desafio_back.domain.Entities.Response
{
    public class GetMotorcycleResponse : IDomainResponse
    {
        public string Ano { get; set; }
        public string Identificador { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

    }
}
