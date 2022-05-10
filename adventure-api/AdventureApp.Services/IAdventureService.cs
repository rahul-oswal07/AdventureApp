using AdventureApp.DataAccess.Models;

namespace AdventureApp.Services
{
    public interface IAdventureService
    {
        Task<IEnumerable<AdventureDto>> GetAdventures();

        Task<AdventureDto> CreateAdventure(CreateAdventureDto adventure);

        Task<AdventureDto> GetAdventureById(int id);

    }
}
