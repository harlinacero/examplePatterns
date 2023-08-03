using AutoMapper;
using PruebaIngresoBibliotecario.Api.Aplication.Dto;
using PruebaIngresoBibliotecario.Api.Domain.Entities;

namespace PruebaIngresoBibliotecario.Api.Aplication.AutoMapper
{
    public sealed class MapperProfile : Profile
    {
        /// <summary>
        /// Mapeador de objetos
        /// </summary>
        public MapperProfile() : base()
        {
            CreateMap<PrestamoRequest, Prestamo>().ReverseMap();
            CreateMap<PrestamoCommandResult, Prestamo>()
                .ForMember(dto => dto.TipoUsuario, e => e.MapFrom(ent => ent.TipoUsuario.ToString()))
                .ReverseMap();
            CreateMap<PrestamoQueryResult, Prestamo>()
                .ForMember(dto => dto.TipoUsuario, e => e.MapFrom(ent => ent.TipoUsuarioServicioBibliteca))
                .ForMember(dto => dto.FechaMaximaDevolucion, e => e.MapFrom(ent => ent.FechaDevolucionPrestamoLibro))
                .ForMember(dto => dto.IdentificacionUsuario, e => e.MapFrom(ent => ent.IdUsuarioPrestamoLibro))
                .ForMember(dto => dto.Isbn, e => e.MapFrom(ent => ent.IsbnLibroPrestamo))
                .ForMember(dto => dto.Id, e => e.MapFrom(ent => ent.IdPrestamoLibro))
                .ReverseMap();
        }
    }
}
