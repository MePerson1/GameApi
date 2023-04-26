using AutoMapper;
using FirstWebApi.Dto;
using FirstWebApi.Models;

namespace FirstWebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, CreateReviewDto>();
        }

    }
}
