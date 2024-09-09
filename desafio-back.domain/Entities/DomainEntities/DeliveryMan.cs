using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Models.Entities
{
    public class DeliveryMan : EntityBase
    {
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string? Numero_cnh { get; set; }
        public string? Tipo_cnh { get; set; }
        public string? Imagem_cnh { get; set; }

        public IEnumerable<Rental>? RentalCollection { get; set; }
    }

}
