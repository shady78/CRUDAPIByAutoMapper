using AutoMapper;
using CRUDAPI.DTO;
using CRUDAPI.Models;

namespace CRUDAPI.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}
