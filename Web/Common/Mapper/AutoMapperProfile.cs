using AutoMapper;
using Data.Models;
using System;
using Web.Models;

namespace Web.Common.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var now = DateTime.Now;

            CreateMap<RenderHTMLViewModel, HTMLExample>()
                .ForMember(x => x.CreatedDate, x => x.MapFrom(s => now))
                .ForMember(x => x.LastEditedDate, x => x.MapFrom(s => now))
                .ForMember(x => x.PreviousHTMLCode, x => x.MapFrom(s => s.HTMLCode));

            CreateMap<HTMLExample, RenderHTMLViewModel>();
        }
    }
}
