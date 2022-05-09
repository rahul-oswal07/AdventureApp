using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;

namespace AdventureApp.Services
{
    public class AdventureService : IAdventureService
    {
        #region Private Variables

        private readonly IAdventureRepository adventureRepository;

        #endregion

        #region Constructor

        public AdventureService(IAdventureRepository adventureRepository)
        {
            this.adventureRepository = adventureRepository;
        }

        #endregion

        #region Public Methods

        public async Task<bool> CreateAdventure(Adventure adventure)
        {
            if (adventure == null)
            {
                throw new ArgumentNullException("Adventure cannot be null");
            }
            await adventureRepository.AddAdventure(adventure);
            return true;
        }

        public async Task<Adventure> GetAdventureById(int id)
        {
            return await adventureRepository.GetAdventure(id);
        }

        public async Task<IEnumerable<AdventureDto>> GetAdventures()
        {
            return await adventureRepository.GetAdventures();
        }

        public async Task<UserAdventure> SaveUserAdventure(int userId, int adventuerId, int questionId)
        {
            return await adventureRepository.SaveUserAdventure(userId, adventuerId, questionId);
        }

        #endregion
    }
}