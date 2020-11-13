namespace PortafolioWebAdministracion.Helpers
{
    using AutoMapper;
    using PortafolioWebAdministracion.DTOs;
    using PortafolioWebAdministracion.EntityModels;
    using PortafolioWebAdministracion.Models;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Biografico, BiograficoDTO>().ReverseMap();
            CreateMap<Certificacion, CertificacionDTO>().ReverseMap();
            CreateMap<Formacion, FormacionDTO>().ReverseMap();
            CreateMap<ExperienciaLaboral, ExperienciaLaboralDTO>().ReverseMap();
            CreateMap<Habilidad, HabilidadDTO>().ReverseMap();
            CreateMap<Referencia, ReferenciaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
