using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IAdventureRepository
    {
        Task<IEnumerable<AdventureDto>> GetAdventures();
        Task<Adventure> GetAdventure(int adventureId);
        Task<Adventure> AddAdventure(Adventure adventure);
        void DeleteAdventure(int adventureId);

        Task<UserAdventure> SaveUserAdventure(int userId, int adventuerId, int questionId);
    }
}
