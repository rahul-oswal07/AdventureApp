using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AutoMapper;

namespace AdventureApp.Services
{
    public class AdventureService : IAdventureService
    {
        #region Private Variables

        public readonly IAdventureRepository adventureRepository;

        public readonly IMapper mapper;

        #endregion

        #region Constructor

        public AdventureService(IMapper mapper, IAdventureRepository adventureRepository)
        {
            this.adventureRepository = adventureRepository;
            this.mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<AdventureDto>> GetAdventures()
        {
            return await adventureRepository.GetAdventures();
        }

        public async Task<AdventureDto> GetAdventureById(int id)
        {
            return await adventureRepository.GetAdventure(id);
        }

        public async Task<AdventureDto> CreateAdventure(CreateAdventureDto adventureDto)
        {
            Adventure adventure = mapper.Map<Adventure>(adventureDto);
            AdventureDto result = await adventureRepository.CreateAdventure(adventure);
            return result;
        }

        #endregion
    }
}