using AdventureApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class AdventureRepository : IAdventureRepository
    {
        private readonly AdventureDbContext adventureDbContext;

        public AdventureRepository(AdventureDbContext adventureDbContext)
        {
            this.adventureDbContext = adventureDbContext;
        }

        public async Task<Adventure> AddAdventure(Adventure adventure)
        {
            var result = await adventureDbContext.Adventure.AddAsync(adventure);
            await adventureDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteAdventure(int adventureId)
        {
            throw new NotImplementedException();
        }

        public async Task<Adventure> GetAdventure(int adventureId)
        {
            return await adventureDbContext.Adventure.FirstOrDefaultAsync(item => item.Id == adventureId);

        }

        public async Task<IEnumerable<Adventure>> GetAdventures()
        {
            return await adventureDbContext.Adventure
                .ToListAsync();
        }
    }
}
