using AdventureApp.DataAccess.Entities;

namespace AdventureApp.Services
{
    public interface IAdventureService
    {
        Task<IEnumerable<Adventure>> GetAdventures();

        bool CreateAdventure(Adventure adventure);

        Adventure GetAdventureById(int id);
    }
}
