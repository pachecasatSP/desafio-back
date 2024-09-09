using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Models.Entities
{
    public class Rental : EntityBase
    {
        public string Entregador_id { get; set; }
        public string Moto_id { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_termino { get; set; }
        public DateTime Data_previsao_termino { get; set; }
        public RentalPlan Plano { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public Motorcycle Motorcycle { get; set; }
    }

}
