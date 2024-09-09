using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Models.Entities
{
    public class Motorcycle : EntityBase
    {
        public int Ano { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
    }

}
