using desafio_back.domain.Models.Base;
using desafio_back.domain.Models.Entities;

namespace desafio_back.domain.Entities.DomainEntities
{
    public class RentalPlan : EntityBase
    {
        public string Nome { get; set; }
        public int PrazoDias { get; set; }
        public decimal Valor { get; set; }       
    }
}
