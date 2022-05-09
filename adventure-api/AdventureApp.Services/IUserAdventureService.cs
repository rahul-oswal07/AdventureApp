using AdventureApp.DataAccess.Models;

namespace AdventureApp.Services
{
    public interface IUserAdventureService
    {
        Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId);

        Task<UserAdventureDto> GetUserAdventure(int id);

        Task<UserAdventureDto> SaveUserAdventure(int userId, int adventuerId, int questionId);
    }
}
