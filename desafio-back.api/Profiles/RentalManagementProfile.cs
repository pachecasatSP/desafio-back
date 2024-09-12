using AutoMapper;
using desafio_back.api.Models.Request;
using desafio_back.domain.Commands;
using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Entities.Response;

namespace desafio_back.web.api.Profiles
{
    public class RentalManagementProfile : Profile
    {
        public RentalManagementProfile()
        {
            CreateMap<CreateMotorcycleRequest, CreateMotorcycleCommand>();

            CreateMap<CreateMotorcycleCommand, Motorcycle>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Identificador))
                 .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Ano))
                 .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Modelo))
                 .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Placa));

            CreateMap<CreateDeliveryManRequest, CreateDeliveryManCommand>();

            CreateMap<CreateDeliveryManCommand, DeliveryMan>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Identificador))
                .ForMember(dest => dest.CNHNumber, opt => opt.MapFrom(src => src.NumeroCnh))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.CNHType, opt => opt.MapFrom(src => src.TipoCnh))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj));

            CreateMap<CreateRentalRequest, CreateRentalCommand>()
                .ForMember(dest => dest.EntregadorId, opt => opt.MapFrom(src => src.Entregador_id))
                .ForMember(dest => dest.MotoId, opt => opt.MapFrom(src => src.Moto_id))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.Data_inicio))
                .ForMember(dest => dest.DataTermino, opt => opt.MapFrom(src => src.Data_termino))
                .ForMember(dest => dest.DataPrevisaoTermino, opt => opt.MapFrom(src => src.Data_previsao_termino));

            CreateMap<CreateRentalCommand, Rental>()
                .ForMember(dest => dest.DeliveryManId, opt => opt.Ignore())
                .ForMember(dest => dest.MotorcycleId, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.DataTermino))
                .ForMember(dest => dest.ForecastEndDate, opt => opt.MapFrom(src => src.DataPrevisaoTermino));

            CreateMap<Motorcycle, GetMotorcycleResponse>()
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id));

            CreateMap<Rental, GetRentalByIdResponse>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Data_devolucao, opt => opt.MapFrom(src => src.RentalReturn!.Date.ToString("yyy-MM-ddTHH:mm:ssZ")))
                .ForMember(dest => dest.Data_previsao_termino, opt => opt.MapFrom(src => src.ForecastEndDate.ToString("yyy-MM-ddTHH:mm:ssZ")))
                .ForMember(dest => dest.Entregador_Id, opt => opt.MapFrom(src => src.DeliveryMan.Id))
                .ForMember(dest => dest.Data_inicio, opt => opt.MapFrom(src => src.StartDate.ToString("yyy-MM-ddTHH:mm:ssZ")))
                .ForMember(dest => dest.Moto_Id, opt => opt.MapFrom(src => src.Motorcycle.Id))
                .ForMember(dest => dest.Valor_diaria, opt => opt.MapFrom(src => src.Plan.Value));



        }
    }
}
