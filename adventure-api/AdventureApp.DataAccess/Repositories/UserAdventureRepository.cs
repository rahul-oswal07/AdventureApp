using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class UserAdventureRepository : IUserAdventureRepository
    {
        #region Private Fields

        private readonly AdventureDbContext adventureDbContext;
        private readonly IMapper mapper;

        #endregion

        #region Public Constructor
        public UserAdventureRepository(AdventureDbContext adventureDbContext, IMapper mapper)
        {
            this.adventureDbContext = adventureDbContext;
            this.mapper = mapper;

        }

        #endregion

        #region Public Methods

        public async Task<UserAdventureDto> GetUserAdventure(int id)
        {
            UserAdventure userAdventure = adventureDbContext.UserAdventure
                .Where(item => item.Id == id)
                .Include(item => item.Adventure)
                .FirstOrDefault();

            Question question = adventureDbContext.Question.AsEnumerable()
                .Where(x => x.Id == userAdventure.QuestionId)
                .FirstOrDefault();
            IEnumerable<int> selectedQuestions = GetAllSelectedQuestionIds(question);

            var result = adventureDbContext.Question.ToList()
                .Where(item => item.Id == userAdventure.Adventure.RootQuestionId)
                .FirstOrDefault();

            QuestionDto questionDto = mapper.Map<QuestionDto>(result);
            questionDto.IsSelected = selectedQuestions.Any(item => item == result.Id);
            UpdateQuestionsValue(questionDto, selectedQuestions);

            return new UserAdventureDto
            {
                Name = userAdventure.Adventure.Name,
                Question = questionDto
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

        public async Task<UserAdventureDto> SaveUserAdventure(int userId, int adventuerId, int questionId)
        {
            var result = await adventureDbContext.UserAdventure.AddAsync(new UserAdventure
            {
                UserId = userId,
                QuestionId = questionId,
                AdventureId = adventuerId
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

        private IEnumerable<int> GetAllSelectedQuestionIds(Question? question)
        {
            List<int> selectedQuestionIds = new List<int>();
            Question currentQuestion = question;
            selectedQuestionIds.Add(currentQuestion.Id);
            while (currentQuestion?.ParentQuestionId != null)
            {
                selectedQuestionIds.Add(currentQuestion.ParentQuestionId.Value);
                currentQuestion = currentQuestion?.ParentQuestion;
            }

            return selectedQuestionIds;
        }

        #endregion
    }
}
