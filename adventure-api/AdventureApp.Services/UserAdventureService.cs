using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;

namespace AdventureApp.Services
{
    public class UserAdventureService : IUserAdventureService
    {
        #region Private Fields

        private readonly IUserAdventureRepository userAdventureRepository;

        #endregion

        #region Public Constructor

        public UserAdventureService(IUserAdventureRepository userAdventureRepository)
        {
            this.userAdventureRepository = userAdventureRepository;
        }

        #endregion

        #region Public Methods

        public async Task<UserAdventureDto> GetUserAdventure(int id)
        {
            return await userAdventureRepository.GetUserAdventure(id);
        }

        public async Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId)
        {
            return await userAdventureRepository.GetUserAdventures(userId);
        }

        public async Task<UserAdventureDto> SaveUserAdventure(int userId, int adventuerId, int questionId)
        {
            return await userAdventureRepository.SaveUserAdventure(userId, adventuerId, questionId);
        }

        #endregion
    }
}
