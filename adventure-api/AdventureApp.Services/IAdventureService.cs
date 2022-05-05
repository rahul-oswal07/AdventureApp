using AdventureApp.DataAccess.Entities;

namespace AdventureApp.Services
{
    public interface IAdventureService
    {
        Task<IEnumerable<Adventure>> GetAdventures();

        Task<bool> CreateAdventure(Adventure adventure);

        Task<Adventure> GetAdventureById(int id);
    }
}
