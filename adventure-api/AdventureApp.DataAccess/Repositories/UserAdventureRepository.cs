using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class UserAdventureRepository : IUserAdventureRepository
    {
        #region Private Fields

        private readonly AdventureDbContext adventureDbContext;
        
        #endregion

        #region Public Constructor
        public UserAdventureRepository(AdventureDbContext adventureDbContext)
        {
            this.adventureDbContext = adventureDbContext;
        }

        #endregion

        #region Public Methods

        public async Task<UserAdventureDto> GetUserAdventure(int id)
        {
            UserAdventure userAdventure = adventureDbContext.UserAdventure
                .Where(item => item.Id == id)
                .Include(item => item.Adventure)
                .FirstOrDefault();

            return new UserAdventureDto
            {
                Name = userAdventure.Adventure.Name,
                LeafQuestionId = userAdventure.QuestionId,
                RootQuestionId = userAdventure.Adventure.RootQuestionId
            };

        }

        public async Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId)
        {
            return await adventureDbContext.UserAdventure
                .Where(item => item.UserId == userId)
                .Select(item => new UserAdventureDto
                {
                    Id = item.Id,
                    AdventureId = item.AdventureId,
                    Name = item.Adventure.Name
                }).ToListAsync();
        }

        public async Task<UserAdventureDto> AddUserAdventure(CreateUserAdventureDto createAdventureDto)
        {
            CreateUserIfNotExist(adventureDbContext);
            var result = await adventureDbContext.UserAdventure.AddAsync(new UserAdventure
            {
                UserId = createAdventureDto.UserId,
                QuestionId = createAdventureDto.QuestionId,
                AdventureId = createAdventureDto.AdventureId
            });

            await adventureDbContext.SaveChangesAsync();
            return new UserAdventureDto { Id = result.Entity.Id, AdventureId = result.Entity.Id };
        }

        #endregion

        #region Private Methods

        private void UpdateQuestionsValue(QuestionDto question, IEnumerable<int> selectedQuestions)
        {
            if (question == null)
                return;

            if (question.Questions != null && question.Questions.Any())
            {
                foreach (var item in question.Questions)
                {
                    item.IsSelected = selectedQuestions.Any(id => id == item.Id);
                    UpdateQuestionsValue(item, selectedQuestions);
                }
            }
        }


        /// <summary>
        /// Note: this is a temporary method since there is no user creation
        /// mechanism
        /// </summary>
        /// <param name="context">AdventureDbContext</param>
        private void CreateUserIfNotExist(AdventureDbContext context)
        {
            if (!context.User.Any())
            {
                context.User.Add(new User { Name = "Rahul" });
                context.SaveChanges();
            }
        }

        #endregion
    }
}
