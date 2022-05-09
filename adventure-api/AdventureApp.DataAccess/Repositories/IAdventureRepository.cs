using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IAdventureRepository
    {
        Task<IEnumerable<AdventureDto>> GetAdventures();

        Task<Adventure> GetAdventure(int adventureId);
        
        Task<Adventure> AddAdventure(Adventure adventure);

    }
}
