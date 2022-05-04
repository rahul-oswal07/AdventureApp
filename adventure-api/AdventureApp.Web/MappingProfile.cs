using AdventureApp.DataAccess.Entities;
using AdventureApp.Web.ViewModels;
using AutoMapper;

namespace AdventureApp.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Adventure, AdventureViewModel>();
            CreateMap<AdventureViewModel, Adventure>();
        }
    }
}
