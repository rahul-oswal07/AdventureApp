using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class AdventureRepository : IAdventureRepository
    {
        #region Private Variables

        private readonly AdventureDbContext adventureDbContext;

        #endregion

        #region Constructor 

        public AdventureRepository(AdventureDbContext adventureDbContext)
        {
            this.adventureDbContext = adventureDbContext;
        }

        #endregion

        #region Public methods

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
            Adventure adventure = await adventureDbContext.Adventure.Where(item => item.Id == adventureId)
                .Include(item => item.RootQuestion)
                .SingleOrDefaultAsync();

            return adventure;
        }

        public async Task<IEnumerable<AdventureDto>> GetAdventures()
        {
            return await adventureDbContext.Adventure.Select(item => new AdventureDto
            {
                Id = item.Id,
                Name = item.Name,
                RootQuestionId = item.RootQuestionId
            }).ToListAsync();
        }

        public async Task<UserAdventure> SaveUserAdventure(int userId, int adventuerId, int questionId)
        {
            var result = await adventureDbContext.UserAdventure.AddAsync(new UserAdventure
            {
                UserId = userId,
                QuestionId = questionId,
                AdventureId = adventuerId
            });

            await adventureDbContext.SaveChangesAsync();
            return result.Entity;
        }

        #endregion

    }
}
