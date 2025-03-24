using AutoMapper;
using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Core.Entities;

namespace ICI_NoticiasMVC.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tag, TagDTO>().ReverseMap();

            CreateMap<Noticia, NoticiaDTO>()
                .ForMember(dest => dest.SelectedTagIds, opt => opt.MapFrom(src => src.Tags.Select(t => t.Id)))
                .ReverseMap()
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
