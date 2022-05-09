using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.Services
{
    public interface IAdventureService
    {
        Task<IEnumerable<AdventureDto>> GetAdventures();

        Task<bool> CreateAdventure(Adventure adventure);

        Task<Adventure> GetAdventureById(int id);

        Task<UserAdventure> SaveUserAdventure(int userId, int adventuerId, int questionId);
    }
}
