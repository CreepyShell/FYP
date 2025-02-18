using AutoMapper;
using InternetForum.BLL.ModelsDTo;
using InternetForum.DAL.DomainModels;
using System;
using System.Linq;

namespace InternetForum.BLL.MapperSettings
{
    public sealed class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.ReactionIds, src => src.MapFrom(p => p.Reactions.Select(r => r.Id)))
                .ForMember(dest => dest.CommentIds, src => src.MapFrom(p => p.Comments.Select(r => r.Id)));
        }
    }
}
