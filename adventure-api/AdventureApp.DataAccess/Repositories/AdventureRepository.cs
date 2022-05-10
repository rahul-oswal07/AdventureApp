using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class AdventureRepository : IAdventureRepository
    {
        #region Private Variables

        public readonly AdventureDbContext adventureDbContext;

        public readonly IMapper mapper;

        #endregion

        #region Constructor 

        public AdventureRepository(IMapper mapper, AdventureDbContext adventureDbContext)
        {
            this.adventureDbContext = adventureDbContext;
            this.mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<AdventureDto> CreateAdventure(Adventure adventure)
        {
            var result = await adventureDbContext.Adventure.AddAsync(adventure);
            await adventureDbContext.SaveChangesAsync();
            return mapper.Map<AdventureDto>(result.Entity);
        }

        public async Task<AdventureDto> GetAdventure(int adventureId)
        {
            Adventure adventure = await adventureDbContext.Adventure.Where(item => item.Id == adventureId)
                .Include(item => item.RootQuestion)
                .SingleOrDefaultAsync();

            return mapper.Map<AdventureDto>(adventure);
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

        #endregion

    }
}
