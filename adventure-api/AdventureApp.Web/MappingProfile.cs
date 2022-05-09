using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AutoMapper;

namespace AdventureApp.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
            CreateMap<Adventure, AdventureDto>();
            CreateMap<AdventureDto, Adventure>();
        }
    }
}
