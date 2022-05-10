using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IAdventureRepository
    {
        Task<IEnumerable<AdventureDto>> GetAdventures();

        Task<AdventureDto> GetAdventure(int adventureId);
        
        Task<AdventureDto> CreateAdventure(Adventure adventure);

    }
}
