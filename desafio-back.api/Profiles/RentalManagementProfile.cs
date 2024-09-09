using AutoMapper;
using desafio_back.api.Models.Commands;
using desafio_back.domain.Models.Entities;

namespace desafio_back.web.api.Profiles
{
    public class RentalManagementProfile : Profile
    {
        public RentalManagementProfile()
        {
            CreateMap<CreateMotorcycleCommand, Motorcycle>();
            CreateMap<Motorcycle, Motorcycle>()
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Ano))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Placa))
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.InternalId, opt => opt.Ignore());


        }
    }
}
