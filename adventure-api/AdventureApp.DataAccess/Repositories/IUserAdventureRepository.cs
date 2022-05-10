using AdventureApp.DataAccess.Models;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IUserAdventureRepository
    {
        Task<UserAdventureDto> GetUserAdventure(int id);

        Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId);

        Task<UserAdventureDto> AddUserAdventure(CreateUserAdventureDto createAdventureDto);
    }
}
