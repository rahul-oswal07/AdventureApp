using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IUserAdventureRepository
    {
        Task<UserAdventureDto> GetUserAdventure(int adventureId, int userId);

        Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId);
    }
}
