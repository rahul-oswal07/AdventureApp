using AdventureApp.DataAccess.Entities;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IAdventureRepository
    {
        Task<IEnumerable<Adventure>> GetAdventures();
        Task<Adventure> GetAdventure(int adventureId);
        Task<Adventure> AddAdventure(Adventure adventure);
        void DeleteAdventure(int adventureId);
    }
}
